using System;
using System.Collections.Generic;

namespace AlphaTrade
{
    public class Stats
    {
        public static void LogStats(Execution[] executions)
        {
            var trades = groupByTrades(executions);

            int winners = 0, losers = 0;
            int longs = 0, shorts = 0;
            double maxProfit = 0, minProfit = 0;
            double avgWin = 0, avgLose = 0;
            double totalFees = 0, totalProfit = 0;

            foreach (StatsTrade trade in trades)
            {
                if (trade.Side == Side.BUY)
                {
                    longs++;
                }
                else
                {
                    shorts++;
                }

                double profit = trade.Profit(Currency.USD, false);
                if (profit >= 0)
                {
                    winners++;
                    avgWin += profit;
                }
                else
                {
                    losers++;
                    avgLose += profit;
                }

                if (maxProfit == 0 || profit > maxProfit)
                {
                    maxProfit = profit;
                }
                if (minProfit == 0 || profit < minProfit)
                {
                    minProfit = profit;
                }

                totalFees += trade.Fees(Currency.USD);
                totalProfit += profit;
            }

            avgWin /= winners;
            avgLose /= losers;

            // Output to log
            Log.Info(winners + " winners and " + losers + " losers (" + longs + " long, " + shorts + " short)");
            Log.Info("Total profit: " + totalProfit.ToString("f2"));
            Log.Info("Total fees: " + totalFees.ToString("f2"));
            Log.Info("Largest win " + maxProfit.ToString("f2") + ", average win " + avgWin.ToString("f2"));
            Log.Info("Largest loss " + minProfit.ToString("f2") + ", average loss " + avgLose.ToString("f2"));
        }

        private static IList<StatsTrade> groupByTrades(Execution[] executions)
        {
            var list = new List<StatsTrade>();
            StatsTrade trade = null;

            foreach (Execution exec in executions)
            {
                if (trade == null || trade.IsComplete)
                {
                    trade = new StatsTrade();
                    list.Add(trade);
                }

                trade.Executions.Add(exec);
            }

            return list;
        }
    }
}
