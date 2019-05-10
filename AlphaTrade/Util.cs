using System;
using System.Security.Cryptography;
using System.Text;

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

        public static string BitmexSignature(string secret, string method, string endpoint, string expires, string postData)
        {
            string message = method + endpoint + expires + postData;
            byte[] signatureBytes = hmacsha256(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));
            return ByteArrayToString(signatureBytes);
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        public static string BitmexExpires()
        {
            var exp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 86400; // set expires 1 day in the future
            return exp.ToString();
        }

        public static double PNLinUSD(int size, double entryPrice, double exitPrice)
        {
            if (size > 0)
            {
                // Long position
                return Math.Abs(size) * ((1 / entryPrice) - (1 / exitPrice)) * Math.Max(entryPrice, exitPrice);
            }
            else
            {
                // Short position
                return Math.Abs(size) * ((1 / exitPrice) - (1 / entryPrice)) * Math.Min(entryPrice, exitPrice);
            }
        }

        private static byte[] hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }
        }
    }
}
