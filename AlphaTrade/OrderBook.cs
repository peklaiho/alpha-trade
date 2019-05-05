﻿using System;
using System.Collections.Generic;

namespace AlphaTrade
{
    public class OrderBook
    {
        private IDictionary<long, OrderBookEntry> book = new Dictionary<long, OrderBookEntry>();
        private List<long> idList = new List<long>();

        public void Clear()
        {
            this.book.Clear();
            this.idList.Clear();
        }

        public OrderBookEntry[] GetBest(Side side, int count)
        {
            var result = new OrderBookEntry[count];
            int found = 0;

            if (side == Side.BID)
            {
                for (int i = 0; i < idList.Count && found < count; i++)
                {
                    var entry = book[idList[i]];
                    if (entry.Side == side)
                    {
                        result[found++] = entry;
                    }
                }
            }
            else
            {
                for (int i = idList.Count - 1; i >= 0 && found < count; i--)
                {
                    var entry = book[idList[i]];
                    if (entry.Side == side)
                    {
                        result[found++] = entry;
                    }
                }
            }

            return result;
        }

        public void Delete(long id)
        {
            this.book.Remove(id);
            this.idList.Remove(id);
        }

        public void Update(long id, int size, Side side)
        {
            this.book[id].Size = size;
            this.book[id].Side = side;
        }

        public void Insert(long id, int size, double price, Side side)
        {
            this.book.Add(id, new OrderBookEntry()
            {
                Side = side,
                Price = price,
                Size = size
            });

            this.idList.Add(id);
            this.idList.Sort();
        }
    }
}
