using System;

namespace AlphaTrade
{
    public class Execution
    {
        public string OrderId;
        public string Symbol;
        public Side Side;
        public int Size;
        public double Price;

        public override string ToString()
        {
            return ((Side == Side.BUY) ? "Buy " : "Sell ") +
                Size + " at " + Price.ToString("f2");
        }
    }
}
