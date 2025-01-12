﻿using System;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AlphaTrade
{
    public class BitMEXDataFeed : DataFeed
    {
        private readonly string url;
        private readonly string key;
        private readonly string secret;

        private WebSocket ws;

        public BitMEXDataFeed(string url, string key, string secret)
        {
            this.url = url;
            this.key = key;
            this.secret = secret;
        }

        public override void Start(string symbol)
        {
            try
            {
                Log.Info("Connecting to data feed.");

                string endpoint = "/realtime";
                string expires = Util.BitmexExpires();
                string signature = Util.BitmexSignature(this.secret, "GET", endpoint, expires, "");

                string url = this.url + endpoint + "?api-expires=" + expires + "&api-signature=" + signature + "&api-key=" + this.key;

                this.ws = new WebSocket(url);
                ws.OnMessage += Ws_OnMessage;
                ws.Connect();

                Subscribe("quote", symbol);
                Subscribe("trade", symbol);
                Subscribe("orderBookL2_25", symbol);

                Subscribe("execution");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        public override void Stop()
        {
            if (this.ws != null)
            {
                Log.Info("Closing data feed.");

                try
                {
                    this.ws.Close();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }
            }
        }

        private void Subscribe(string table, string symbol = null)
        {
            var args = new JArray();

            if (symbol != null)
            {
                args.Add(table + ":" + symbol);
            }
            else
            {
                args.Add(table);
            }

            var q = new JObject();
            q["op"] = "subscribe";
            q["args"] = args;

            Send(q.ToString());
        }

        private void Send(string query)
        {
            // Log.Network(">> " + query);

            try
            {
                this.ws.Send(query);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void Ws_OnMessage(object sender, MessageEventArgs e)
        {
            // Log.Network("<< " + e.Data);

            var data = JObject.Parse(e.Data);

            if (data["table"] != null && data["action"] != null)
            {
                var table = data["table"].ToString();
                var action = data["action"].ToString();

                if (table == "quote")
                {
                    if (action == "insert")
                    {
                        JArray quoteData = (JArray)data["data"];
                        Quote[] quotes = new Quote[quoteData.Count];

                        for (int i = 0; i < quoteData.Count; i++)
                        {
                            quotes[i] = new Quote()
                            {
                                Symbol = quoteData[i]["symbol"].ToString(),
                                Bid = Convert.ToDouble(quoteData[i]["bidPrice"]),
                                Ask = Convert.ToDouble(quoteData[i]["askPrice"])
                            };
                        }

                        this.RaiseOnQuote(new DataFeedQuoteEventArgs() { Quotes = quotes });
                    }
                }
                else if (table == "trade")
                {
                    if (action == "insert")
                    {
                        JArray tradeData = (JArray)data["data"];
                        Trade[] trades = new Trade[tradeData.Count];

                        for (int i = 0; i < tradeData.Count; i++)
                        {
                            trades[i] = new Trade()
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
                    OrderBookEntry[] entries = new OrderBookEntry[bookData.Count];

                    for (int i = 0; i < bookData.Count; i++)
                    {
                        entries[i] = new OrderBookEntry()
                        {
                            Symbol = bookData[i]["symbol"].ToString(),
                            Id = Convert.ToInt64(bookData[i]["id"]),
                            Price = Convert.ToDouble(bookData[i]["price"]),
                            Size = Convert.ToInt32(bookData[i]["size"]),
                            Side = bookData[i]["side"].ToString() == "Buy" ? Side.BUY : Side.SELL
                        };
                    }

                    DataFeedOrderBookEventArgs.Types type;
                    if (action == "insert")
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
                    else if (action == "partial")
                    {
                        // Ignore for now
                        return;
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
                else if (table == "execution")
                {
                    if (action == "insert")
                    {
                        JArray execData = (JArray)data["data"];
                        List<Execution> executions = new List<Execution>();

                        for (int i = 0; i < execData.Count; i++)
                        {
                            if (execData[i]["ordStatus"].ToString() == "Filled")
                            {
                                executions.Add(new Execution()
                                {
                                    OrderId = execData[i]["orderID"].ToString(),
                                    Symbol = execData[i]["symbol"].ToString(),
                                    Side = execData[i]["side"].ToString() == "Buy" ? Side.BUY : Side.SELL,
                                    Size = Convert.ToInt32(execData[i]["lastQty"]),
                                    Price = Convert.ToDouble(execData[i]["lastPx"])
                                });
                            }
                        }

                        if (executions.Count > 0)
                        {
                            this.RaiseOnExecution(new DataFeedExecutionEventArgs()
                            {
                                Executions = executions.ToArray()
                            });
                        }
                    }
                }
                else
                {
                    Log.Warn(e.Data);
                }
            }
            else if (data["info"] != null)
            {
                Log.Info(data["info"].ToString());
            }
            else if (data["success"] != null && data["subscribe"] != null)
            {
                Log.Info("Subscribed to stream: " + data["subscribe"].ToString());
            }
            else
            {
                // Unknown message, log it
                Log.Warn(e.Data);
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
