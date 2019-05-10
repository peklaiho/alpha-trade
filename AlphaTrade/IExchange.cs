namespace AlphaTrade
{
    public interface IExchange
    {
        ChartData GetChart(string symbol, CandleSize candleSize);
        OrderBook GetOrderBook(string symbol);

        Order[] GetOrders();
        void CreateOrder(Order order);
        void ModifyOrder(Order order);
        void CancelOrder(Order order);
        void CancelAllOrders();

        Position[] GetPositions();
        void ClosePosition(string symbol);
        void CloseAllPositions();
    }
}
