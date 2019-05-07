using System;

namespace AlphaTrade
{
    public abstract class DataFeed
    {
        public event EventHandler<DataFeedQuoteEventArgs> OnQuote;
        public event EventHandler<DataFeedTradeEventArgs> OnTrade;
        public event EventHandler<DataFeedOrderBookEventArgs> OnOrderBook;

        public void RaiseOnQuote(DataFeedQuoteEventArgs quote)
        {
            OnQuote?.Invoke(this, quote);
        }

        public void RaiseOnTrade(DataFeedTradeEventArgs trades)
        {
            OnTrade?.Invoke(this, trades);
        }

        public void RaiseOnOrderBook(DataFeedOrderBookEventArgs book)
        {
            OnOrderBook?.Invoke(this, book);
        }

        public abstract void Start(string symbol);
        public abstract void Stop();
    }
}
