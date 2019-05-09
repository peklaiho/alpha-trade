using System;

namespace AlphaTrade
{
    public class Order
    {
        public string Id;
        public string Symbol;
        public Side Side;
        public OrderType Type;
        public double Price;
        public int Size;

        public override string ToString()
        {
            string str = (Side == Side.BUY) ? "BUY " : "SELL ";
            str += Size + " " + Symbol + " at ";
            str += (Type == OrderType.MARKET) ? "MARKET" : Price.ToString("f2");
            return str;
        }

        public string TypeToString()
        {
            string str = "";

            if (Type == OrderType.STOP)
            {
                str = "STOP ";
            }

            return str + ((Side == Side.BUY) ? "BUY" : "SELL");
        }
    }
}
