using System;

namespace AlphaTrade
{
    public class DataFeedOrderBookEventArgs
    {
        public enum Types
        {
            Insert,
            Update,
            Delete
        };

        public Types Type;
        public OrderBookEntry[] Entries;
    }
}
