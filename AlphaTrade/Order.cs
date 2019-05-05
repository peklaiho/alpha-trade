using System;

namespace AlphaTrade
{
    class Order
    {
        public long Id;
        public Side Side;
        public OrderType Type;
        public double Price;
        public int Size;

        public override string ToString()
        {
            string str = (Side == Side.BUY) ? "BUY " : "SELL ";
            str += Size + " at ";
            str += (Type == OrderType.MARKET) ? "MARKET" : Price.ToString("f2");
            return str;
        }
    }
}
