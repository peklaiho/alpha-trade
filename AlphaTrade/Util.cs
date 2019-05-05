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
    }
}
