using System;
using System.Collections.Generic;

namespace AlphaTrade
{
    public class StatsTrade
    {
        const double SATOSHI_RATE = 0.00000001;

        public IList<Execution> Executions = new List<Execution>();
        
        public Side Side
        {
            get
            {
                return Executions[0].Side;
            }
        }

        public double Profit(Currency c, bool reduceFees = false)
        {
            double profit;

            if (c == Currency.SATOSHI)
            {
                long buys = 0, sells = 0;

                foreach (Execution ex in Executions)
                {
                    if (ex.Side == Side.BUY)
                    {
                        buys += ex.ValueSt;
                    }
                    else
                    {
                        sells += ex.ValueSt;
                    }
                }

                profit = buys - sells;
            }
            else if (c == Currency.BTC)
            {
                profit = Profit(Currency.SATOSHI) * SATOSHI_RATE;
            }
            else
            {
                profit = Profit(Currency.BTC) * LastPrice;
            }

            if (reduceFees)
            {
                profit -= Fees(c);
            }

            return profit;
        }

        public double Fees(Currency c)
        {
            if (c == Currency.SATOSHI)
            {
                long total = 0;
                foreach (Execution ex in Executions)
                {
                    total += ex.FeeSt;
                }
                return total;
            }
            else if (c == Currency.BTC)
            {
                return Fees(Currency.SATOSHI) * SATOSHI_RATE;
            }
            else
            {
                return Fees(Currency.BTC) * LastPrice;
            }
        }

        public double AvgPrice(Side side)
        {
            double total = 0;

            foreach (Execution ex in Executions)
            {
                if (ex.Side == side)
                {
                    total += ex.Size * ex.Price;
                }
            }

            return total / Size(side);
        }

        public int Size(Side side)
        {
            int size = 0;

            foreach (Execution ex in Executions)
            {
                if (ex.Side == side)
                {
                    size += ex.Size;
                }
            }

            return size;
        }

        public bool IsComplete
        {
            get
            {
                return Size(Side.BUY) == Size(Side.SELL);
            }
        }

        public double LastPrice
        {
            get
            {
                return Executions[Executions.Count - 1].Price;
            }
        }
    }
}
