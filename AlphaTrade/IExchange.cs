namespace AlphaTrade
{
    public interface IExchange
    {
        ChartData GetChart(string symbol, CandleSize candleSize);
        OrderBook GetOrderBook(string symbol);

        void CreateOrder(Order order);
        void ModifyOrder(Order order);
        void CancelOrder(Order order);
        Order[] GetOrders();
    }
}
