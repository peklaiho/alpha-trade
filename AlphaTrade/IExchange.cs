namespace AlphaTrade
{
    public interface IExchange
    {
        ChartData GetChart(string symbol, CandleSize candleSize);
        OrderBook GetOrderBook(string symbol);

        void CreateOrder(Order order);
        void ModifyOrder(string id, int size, double price);
        void CancelOrder(string id);

        Order[] GetOrders();
        Position[] GetPositions();
    }
}
