﻿using System;
using WebSocketSharp;
using Newtonsoft.Json.Linq;

namespace AlphaTrade
{
    public class BitMEXDataFeed : DataFeed
    {
        private readonly string url;
        private readonly string symbol;

        private WebSocket ws;

        public BitMEXDataFeed(string url, string symbol)
        {
            this.url = url;
            this.symbol = symbol;
        }

        public override void Start()
        {
            string url = this.url + "/realtime";

            this.ws = new WebSocket(url);
            ws.OnMessage += Ws_OnMessage;
            ws.Connect();
            this.Subscribe("trade");
            this.Subscribe("orderBookL2_25");
        }

        public override void Stop()
        {
            if (this.ws != null)
            {
                this.ws.Close();
            }
        }

        private void Subscribe(string table)
        {
            var args = new JArray();
            args.Add(table + ":" + symbol);

            var q = new JObject();
            q["op"] = "subscribe";
            q["args"] = args;

            Send(q.ToString());
        }

        private void Send(string query)
        {
            Log.Debug(">> " + query);

            this.ws.Send(query);
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            Log.Debug("<< " + e.Data);

            var data = JObject.Parse(e.Data);

            if (data["table"] != null && data["action"] != null)
            {
                var table = data["table"].ToString();
                var action = data["action"].ToString();

                if (table == "trade")
                {
                    if (action == "insert")
                    {
                        JArray tradeData = (JArray)data["data"];
                        DataFeedTrade[] trades = new DataFeedTrade[tradeData.Count];

                        for (int i = 0; i < tradeData.Count; i++)
                        {
                            trades[i] = new DataFeedTrade()
                            {
                                Symbol = tradeData[i]["symbol"].ToString(),
                                Time = Util.ParseUnixTimestamp(tradeData[i]["timestamp"].ToString()),
                                Price = Convert.ToDouble(tradeData[i]["price"]),
                                Volume = Convert.ToInt64(tradeData[i]["size"]),
                                Direction = ParseDirection(tradeData[i]["tickDirection"].ToString())
                            };
                        }

                        this.RaiseOnTrade(new DataFeedTradeEventArgs() { Trades = trades });
                    }
                }
                else if (table == "orderBookL2_25")
                {
                    JArray bookData = (JArray)data["data"];
                    DataFeedOrderBook[] entries = new DataFeedOrderBook[bookData.Count];

                    for (int i = 0; i < bookData.Count; i++)
                    {
                        entries[i] = new DataFeedOrderBook()
                        {
                            Symbol = bookData[i]["symbol"].ToString(),
                            Id = Convert.ToInt64(bookData[i]["id"]),
                            Price = Convert.ToDouble(bookData[i]["price"]),
                            Size = Convert.ToInt32(bookData[i]["size"]),
                            Side = bookData[i]["side"].ToString() == "Buy" ? Side.BID : Side.ASK
                        };
                    }

                    DataFeedOrderBookEventArgs.Types type;
                    if (action == "insert" || action == "partial")
                    {
                        type = DataFeedOrderBookEventArgs.Types.Insert;
                    }
                    else if (action == "update")
                    {
                        type = DataFeedOrderBookEventArgs.Types.Update;
                    }
                    else if (action == "delete")
                    {
                        type = DataFeedOrderBookEventArgs.Types.Delete;
                    }
                    else
                    {
                        Log.Warn("Unknown action for order book: " + action);
                        return;
                    }

                    this.RaiseOnOrderBook(new DataFeedOrderBookEventArgs()
                    {
                        Type = type,
                        Entries = entries
                    });
                }
            }
        }

        private int ParseDirection(string dir)
        {
            switch (dir)
            {
                case "PlusTick": return 2;
                case "ZeroPlusTick": return 1;
                case "ZeroMinusTick": return -1;
                case "MinusTick": return -2;
                default: return 0;
            }
        }
    }
}
