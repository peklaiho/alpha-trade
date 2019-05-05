using System;
using System.Collections.Generic;

namespace AlphaTrade
{
    public class ChartData
    {
        private IList<Candle> candles = new List<Candle>();
        private int candleSize; // seconds

        public ChartData(int candleSize)
        {
            this.candleSize = candleSize;
        }

        public void Add(Candle candle)
        {
            this.candles.Add(candle);
        }

        public void Clear()
        {
            this.candles.Clear();
        }

        public IList<Candle> GetCandles()
        {
            return this.candles;
        }

        public (double, double) GetMinMax(int countFromEnd)
        {
            double min = -1, max = -1;

            for (int i = this.candles.Count - countFromEnd; i < this.candles.Count; i++)
            {
                var c = this.candles[i];

                if (min == -1 || c.Low < min)
                {
                    min = c.Low;
                }
                if (max == -1 || c.High > max)
                {
                    max = c.High;
                }
            }

            return (min, max);
        }

        public int GetCandleSize()
        {
            return this.candleSize;
        }

        public void Update(long time, double price, long volume)
        {
            if (this.candles.Count == 0)
            {
                Log.Warn("Attempt to update ChartData with no existing candles.");
                return;
            }

            var last = this.candles[this.candles.Count - 1];

            if (last.Contains(time))
            {
                last.Update(price, volume);
            }
            else
            {
                var newCandle = new Candle()
                {
                    StartTime = last.EndTime,
                    EndTime = last.EndTime + candleSize,
                    Open = last.Close,
                    Close = price,
                    High = Math.Max(last.Close, price),
                    Low = Math.Min(last.Close, price),
                    Volume = volume
                };

                if (newCandle.Contains(time))
                {
                    this.candles.Add(newCandle);
                }
                else
                {
                    Log.Warn("Attempt to update ChartData would skip a candle.");
                }
            }
        }
    }
}
