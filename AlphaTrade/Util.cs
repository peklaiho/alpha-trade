using System;

namespace AlphaTrade
{
    public class Util
    {
        public static long ParseUnixTimestamp(string strTime)
        {
            var time = DateTime.Parse(strTime);
            time = DateTime.SpecifyKind(time, DateTimeKind.Utc);
            return ((DateTimeOffset)time).ToUnixTimeSeconds();
        }

        public static string CandleSizeToString(CandleSize size)
        {
            switch (size)
            {
                case CandleSize.MIN_1:
                    return "1 min";
                case CandleSize.MIN_5:
                    return "5 min";
                case CandleSize.HOUR_1:
                    return "1 hour";
                case CandleSize.DAY_1:
                    return "1 day";
            }

            return "unknown";
        }
    }
}
