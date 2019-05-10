using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace AlphaTrade
{
    public class BitMEX : IExchange
    {
        private readonly string url;
        private readonly string key;
        private readonly string secret;

        public BitMEX(string url, string key, string secret)
        {
            this.url = url;
            this.key = key;
            this.secret = secret;
        }

        public ChartData GetChart(string symbol, CandleSize candleSize)
        {
            ChartData chartData = new ChartData(candleSize);

            var param = new Dictionary<string, string>();
            param["symbol"] = symbol;
            param["binSize"] = formatCandleSize(candleSize);
            param["partial"] = "true";
            param["count"] = "500";
            param["reverse"] = "true";
            param["columns"] = "timestamp,open,close,high,low,volume";

            string rawData = Query("GET", "/trade/bucketed", param, false, false);
            JArray data = JArray.Parse(rawData);

            for (int i = data.Count - 1; i >= 0; i--)
            {
                var endTime = Util.ParseUnixTimestamp(data[i]["timestamp"].ToString());

                var candle = new Candle()
                {
                    StartTime = endTime - (int)chartData.GetCandleSize(),
                    EndTime = endTime,
                    Open = Convert.ToDouble(data[i]["open"]),
                    Close = Convert.ToDouble(data[i]["close"]),
                    High = Convert.ToDouble(data[i]["high"]),
                    Low = Convert.ToDouble(data[i]["low"]),
                    Volume = Convert.ToInt64(data[i]["volume"])
                };

                chartData.Add(candle);
            }

            return chartData;
        }

        public OrderBook GetOrderBook(string symbol)
        {
            OrderBook bookData = new OrderBook();

            var param = new Dictionary<string, string>();
            param["symbol"] = symbol;
            param["depth"] = "50";

            string rawData = Query("GET", "/orderBook/L2", param, false, false);
            JArray data = JArray.Parse(rawData);

            foreach (JObject entryData in data)
            {
                var entry = new OrderBookEntry()
                {
                    Id = Convert.ToInt64(entryData["id"]),
                    Size = Convert.ToInt32(entryData["size"]),
                    Price = Convert.ToDouble(entryData["price"]),
                    Side = entryData["side"].ToString() == "Buy" ? Side.BUY : Side.SELL
                };

                bookData.Insert(entry);
            }

            return bookData;
        }

        public Order[] GetOrders()
        {
            var param = new Dictionary<string, string>();
            param["filter"] = "{\"open\": true}";

            string rawData = Query("GET", "/order", param, true, false);
            JArray data = JArray.Parse(rawData);

            Order[] orders = new Order[data.Count];

            for (int i = 0; i < data.Count; i++)
            {
                JObject orderData = (JObject)data[i];

                var order = new Order()
                {
                    Id = orderData["orderID"].ToString(),
                    Symbol = orderData["symbol"].ToString(),
                    Side = orderData["side"].ToString() == "Buy" ? Side.BUY : Side.SELL,
                    Type = this.parseType(orderData["ordType"].ToString()),
                    Size = Convert.ToInt32(orderData["orderQty"]),
                    Unfilled = Convert.ToInt32(orderData["leavesQty"])
                };

                if (order.Type == OrderType.STOP)
                {
                    order.Price = Convert.ToDouble(orderData["stopPx"]);
                }
                else if (order.Type == OrderType.LIMIT)
                {
                    order.Price = Convert.ToDouble(orderData["price"]);
                }

                orders[i] = order;
            }

            return orders;
        }

        public void CreateOrder(Order order)
        {
            var param = new Dictionary<string, string>();
            param["symbol"] = order.Symbol;
            param["side"] = order.Side == Side.BUY ? "Buy" : "Sell";
            param["orderQty"] = order.Size.ToString();

            if (order.Type == OrderType.STOP)
            {
                param["stopPx"] = order.Price.ToString("f2");
                param["ordType"] = "Stop";
            }
            else
            {
                param["price"] = order.Price.ToString("f2");

                if (order.Type == OrderType.LIMIT)
                {
                    param["ordType"] = "Limit";
                }
                else
                {
                    param["ordType"] = "Market";
                }
            }

            string rawData = Query("POST", "/order", param, true, true);
            JObject data = JObject.Parse(rawData);
            order.Id = data["orderID"].ToString();
        }

        public void ModifyOrder(Order order)
        {
            var param = new Dictionary<string, string>();
            param["orderID"] = order.Id;
            param["orderQty"] = order.Size.ToString();

            if (order.Type == OrderType.STOP)
            {
                param["stopPx"] = order.Price.ToString("f2");
            }
            else
            {
                param["price"] = order.Price.ToString("f2");
            }

            Query("PUT", "/order", param, true, true);
        }

        public void CancelOrder(Order order)
        {
            var param = new Dictionary<string, string>();
            param["orderID"] = order.Id;
            Query("DELETE", "/order", param, true, true);
        }

        public void CancelAllOrders()
        {
            Query("DELETE", "/order/all", null, true, false);
        }

        public Position[] GetPositions()
        {
            return new Position[]
            {
                new Position()
                {
                    Symbol = "XBTUSD",
                    Size = 12,
                    Price = 5820.65
                },
                new Position()
                {
                    Symbol = "ETHUSD",
                    Size = -8,
                    Price = 5830.34
                }
            };
        }

        public void ClosePosition(string symbol)
        {

        }

        public void CloseAllPositions()
        {

        }

        private OrderType parseType(string type)
        {
            if (type == "Stop")
            {
                return OrderType.STOP;
            }
            else if (type == "Limit")
            {
                return OrderType.LIMIT;
            }

            return OrderType.MARKET;
        }

        private string BuildQueryData(Dictionary<string, string> param)
        {
            if (param == null)
                return "";

            StringBuilder b = new StringBuilder();
            foreach (var item in param)
            {
                b.Append(string.Format("&{0}={1}", item.Key, WebUtility.UrlEncode(item.Value)));
            }

            try { return b.ToString().Substring(1); }
            catch (Exception) { return ""; }
        }

        private string BuildJSON(Dictionary<string, string> param)
        {
            if (param == null)
                return "";

            var entries = new JObject();
            foreach (var item in param)
            {
                entries[item.Key] = item.Value;
            }

            return entries.ToString();
        }

        public string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        private long GetExpires()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 86400; // set expires 1 day in the future
        }

        private string formatCandleSize(CandleSize size)
        {
            switch (size)
            {
                case CandleSize.MIN_1:
                    return "1m";
                case CandleSize.MIN_5:
                    return "5m";
                case CandleSize.HOUR_1:
                    return "1h";
                case CandleSize.DAY_1:
                    return "1d";
            }

            return "";
        }

        private string Query(string method, string function, Dictionary<string, string> param = null, bool auth = false, bool json = false)
        {
            string paramData = json ? BuildJSON(param) : BuildQueryData(param);
            string url = "/api/v1" + function + ((method == "GET" && paramData != "") ? "?" + paramData : "");
            string postData = (method != "GET") ? paramData : "";

            Log.Debug(">> " + method + " " + url + " " + postData);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(this.url + url);
            webRequest.Method = method;

            if (auth)
            {
                string expires = GetExpires().ToString();
                string message = method + url + expires + postData;
                byte[] signatureBytes = hmacsha256(Encoding.UTF8.GetBytes(this.secret), Encoding.UTF8.GetBytes(message));
                string signatureString = ByteArrayToString(signatureBytes);

                webRequest.Headers.Add("api-expires", expires);
                webRequest.Headers.Add("api-key", this.key);
                webRequest.Headers.Add("api-signature", signatureString);
            }

            if (postData != "")
            {
                webRequest.ContentType = json ? "application/json" : "application/x-www-form-urlencoded";
                var data = Encoding.UTF8.GetBytes(postData);
                using (var stream = webRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            using (WebResponse webResponse = webRequest.GetResponse())
            {
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    string response = sr.ReadToEnd();
                    Log.Debug("<< " + response);
                    return response;
                }
            }
        }

        private byte[] hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }
        }
    }
}
