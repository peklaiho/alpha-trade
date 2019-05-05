using System;

namespace AlphaTrade
{
    public class Candle
    {
        public long StartTime;
        public long EndTime;
        public double Open;
        public double Close;
        public double High;
        public double Low;
        public long Volume;

        public bool Contains(long time)
        {
            return time >= StartTime && time <= EndTime;
        }

        public void Update(double price, long volume)
        {
            Close = price;

            if (price < Low)
            {
                Low = price;
            }
            if (price > High)
            {
                High = price;
            }

            Volume += volume;
        }
    }
}
