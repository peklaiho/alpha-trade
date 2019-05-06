namespace AlphaTrade
{
    public interface IExchange
    {
        ChartData GetChart(string symbol, CandleSize candleSize);
        OrderBook GetOrderBook(string symbol);
    }
}
