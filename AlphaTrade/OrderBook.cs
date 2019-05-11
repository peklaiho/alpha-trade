using System;
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

        public double GetBid()
        {
            var res = GetBest(Side.BUY, 1);

            if (res[0] != null)
            {
                return res[0].Price;
            }

            return 0;
        }

        public double GetAsk()
        {
            var res = GetBest(Side.SELL, 1);

            if (res[0] != null)
            {
                return res[0].Price;
            }

            return 0;
        }

        public OrderBookEntry[] GetBest(Side side, int count)
        {
            var result = new OrderBookEntry[count];
            int found = 0;

            if (side == Side.BUY)
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

        public void InsertOrUpdate(OrderBookEntry entry)
        {
            if (this.book.ContainsKey(entry.Id))
            {
                // update old entry
                this.book[entry.Id].Size = entry.Size;
                this.book[entry.Id].Side = entry.Side;
            }
            else
            {
                // new entry
                if (entry.Price > 0)
                {
                    this.book[entry.Id] = entry;
                    this.idList.Add(entry.Id);
                    this.idList.Sort();
                }
                else
                {
                    Log.Warn("Update to order book with missing price.");
                }
            }
        }
    }
}
