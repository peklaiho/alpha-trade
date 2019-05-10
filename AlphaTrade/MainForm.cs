using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class MainForm : Form
    {
        private IExchange exchange;
        private DataFeed dataFeed;
        private string symbol;

        private LogForm logForm;

        private int lotSize = 100;
        private double tickSize = 0.5;
        private double bidPrice = 0;
        private double askPrice = 0;

        public MainForm(IExchange exchange, DataFeed dataFeed, string symbol)
        {
            this.exchange = exchange;
            this.dataFeed = dataFeed;
            this.symbol = symbol;

            InitializeComponent();
            updateStatusStrip();

            // Create log form
            this.logForm = new LogForm();
            logForm.MdiParent = this;
            logForm.Show();

            this.timer1.Start();
        }

        public void CreateOrder(Order order)
        {
            Log.Info("New order: " + order.ToString());
            queueAction(new Action(Action.Types.CREATE_ORDER, order));
        }

        public void ModifyOrder(Order order)
        {
            Log.Info("Modify order: " + order.ToString());
            queueAction(new Action(Action.Types.MODIFY_ORDER, order));
        }

        public void CancelOrder(Order order)
        {
            Log.Info("Cancel order: " + order.ToString());
            queueAction(new Action(Action.Types.CANCEL_ORDER, order));
        }

        public void ClosePosition(string symbol)
        {
            Log.Info("Close position: " + symbol);
            queueAction(new Action(Action.Types.CLOSE_POSITION, symbol));
        }

        private void updateStatusStrip()
        {
            this.toolStripStatusLabelInfo.Text = 
                "Bid: " + bidPrice.ToString("f2") +
                "  Ask: " + askPrice.ToString("f2");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                // Market orders
                case Keys.Control | Keys.Up:
                    hotkeyOrder(Side.BUY, 1, 999);
                    return true;
                case Keys.Control | Keys.Down:
                    hotkeyOrder(Side.SELL, 1, 999);
                    return true;

                // Limit buys
                case Keys.Control | Keys.Add:
                    hotkeyOrder(Side.BUY, 1, 0);
                    return true;
                case Keys.Control | Keys.NumPad1:
                    hotkeyOrder(Side.BUY, 1, -1);
                    return true;
                case Keys.Control | Keys.NumPad2:
                    hotkeyOrder(Side.BUY, 1, -2);
                    return true;
                case Keys.Control | Keys.NumPad3:
                    hotkeyOrder(Side.BUY, 1, -3);
                    return true;

                // Limit sells
                case Keys.Control | Keys.Subtract:
                    hotkeyOrder(Side.SELL, 1, 0);
                    return true;
                case Keys.Control | Keys.NumPad7:
                    hotkeyOrder(Side.SELL, 1, +1);
                    return true;
                case Keys.Control | Keys.NumPad8:
                    hotkeyOrder(Side.SELL, 1, +2);
                    return true;
                case Keys.Control | Keys.NumPad9:
                    hotkeyOrder(Side.SELL, 1, +3);
                    return true;

                // Other
                case Keys.Control | Keys.NumPad0:
                    queueAction(new Action(Action.Types.CANCEL_ALL_ORDERS));
                    return true;
                case Keys.Control | Keys.Delete:
                    // queueAction(new Action(Action.Types.CLOSE_ALL_POSITIONS));
                    ClosePosition(symbol);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void queueAction(Action action)
        {
            var bg = new BackgroundWorker();
            bg.DoWork += this.backgroundWorkerAction_DoWork;
            bg.RunWorkerCompleted += this.backgroundWorkerAction_RunWorkerCompleted;
            bg.RunWorkerAsync(action);
        }

        private void hotkeyOrder(Side side, int lots, int relPrice)
        {
            var order = new Order() { Symbol = symbol, Side = side, Size = lotSize * lots, Type = OrderType.LIMIT };
            order.Unfilled = order.Size;

            if (relPrice == 999)
            {
                order.Type = OrderType.MARKET;
            }
            else
            {
                if (side == Side.BUY)
                {
                    order.Price = bidPrice + relPrice;
                }
                else
                {
                    order.Price = askPrice + relPrice;
                }
            }

            this.CreateOrder(order);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.backgroundWorkerDataFeed.IsBusy)
            {
                this.backgroundWorkerDataFeed.CancelAsync();
                Thread.Sleep(200);
            }
        }

        #region Menu
        private void startDataFeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.backgroundWorkerDataFeed.IsBusy)
            {
                this.backgroundWorkerDataFeed.RunWorkerAsync();
            }
        }

        private void stopDataFeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorkerDataFeed.IsBusy)
            {
                this.backgroundWorkerDataFeed.CancelAsync();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queueAction(new Action(Action.Types.WINDOW_CHART, CandleSize.DAY_1));
        }

        private void hourlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queueAction(new Action(Action.Types.WINDOW_CHART, CandleSize.HOUR_1));
        }

        private void min5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queueAction(new Action(Action.Types.WINDOW_CHART, CandleSize.MIN_5));
        }

        private void min1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queueAction(new Action(Action.Types.WINDOW_CHART, CandleSize.MIN_1));
        }

        private void positionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queueAction(new Action(Action.Types.WINDOW_POSITIONS));
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queueAction(new Action(Action.Types.WINDOW_ORDERS));
        }

        private void orderBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queueAction(new Action(Action.Types.WINDOW_ORDER_BOOK));
        }

        private void orderEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OrderEntryForm(this.symbol, this.lotSize, this.tickSize, this.bidPrice, this.askPrice);
            form.MdiParent = this;
            form.Show();
        }

        private void tradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TradesForm(this.symbol);
            form.MdiParent = this;
            form.Show();
        }
        #endregion

        #region BackgroundWorkers
        private void backgroundWorkerAction_DoWork(object sender, DoWorkEventArgs e)
        {
            Action action = (Action)e.Argument;
            e.Result = action;

            try
            {
                switch (action.Type)
                {
                    // Orders
                    case Action.Types.CREATE_ORDER:
                        exchange.CreateOrder((Order)action.Args);
                        break;
                    case Action.Types.MODIFY_ORDER:
                        exchange.ModifyOrder((Order)action.Args);
                        break;
                    case Action.Types.CANCEL_ORDER:
                        exchange.CancelOrder((Order)action.Args);
                        break;
                    case Action.Types.CANCEL_ALL_ORDERS:
                        Log.Info("Cancel all orders!");
                        exchange.CancelAllOrders();
                        break;
                    case Action.Types.UPDATE_ORDERS:
                        action.Result = exchange.GetOrders();
                        break;

                    // Positions
                    case Action.Types.CLOSE_POSITION:
                        exchange.ClosePosition((string)action.Args);
                        break;
                    case Action.Types.CLOSE_ALL_POSITIONS:
                        Log.Info("Close all positions!");
                        exchange.CloseAllPositions();
                        break;
                    case Action.Types.UPDATE_POSITIONS:
                        action.Result = exchange.GetPositions();
                        break;

                    // Windows
                    case Action.Types.WINDOW_ORDERS:
                        action.Result = exchange.GetOrders();
                        break;
                    case Action.Types.WINDOW_POSITIONS:
                        action.Result = exchange.GetPositions();
                        break;
                    case Action.Types.WINDOW_CHART:
                        action.Result = exchange.GetChart(symbol, (CandleSize) action.Args);
                        break;
                    case Action.Types.WINDOW_ORDER_BOOK:
                        action.Result = exchange.GetOrderBook(symbol);
                        break;

                    default:
                        Log.Error("Unhandled action: " + action.Type);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                action.Result = ex;
            }
        }

        private void backgroundWorkerAction_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Action action = (Action)e.Result;

            if (action.Type == Action.Types.CREATE_ORDER ||
                action.Type == Action.Types.MODIFY_ORDER ||
                action.Type == Action.Types.CANCEL_ORDER ||
                action.Type == Action.Types.CANCEL_ALL_ORDERS ||
                action.Type == Action.Types.CLOSE_POSITION ||
                action.Type == Action.Types.CLOSE_ALL_POSITIONS)
            {
                queueAction(new Action(Action.Types.UPDATE_POSITIONS));
                queueAction(new Action(Action.Types.UPDATE_ORDERS));
                return;
            }

            if (action.Result != null && !(action.Result is Exception))
            { 
                switch (action.Type)
                {
                    case Action.Types.WINDOW_ORDERS:
                        var orders = new OrdersForm((Order[])action.Result, lotSize, tickSize);
                        orders.MdiParent = this;
                        orders.Show();
                        break;

                    case Action.Types.WINDOW_POSITIONS:
                        var pos = new PositionsForm((Position[])action.Result);
                        pos.MdiParent = this;
                        pos.Show();
                        break;

                    case Action.Types.WINDOW_CHART:
                        var chart = new ChartForm((ChartData)action.Result, this.symbol);
                        chart.MdiParent = this;
                        chart.Show();
                        break;

                    case Action.Types.WINDOW_ORDER_BOOK:
                        var book = new OrderBookForm((OrderBook)action.Result, this.symbol);
                        book.MdiParent = this;
                        book.Show();
                        break;

                    case Action.Types.UPDATE_ORDERS:
                        foreach (var form in this.MdiChildren)
                        {
                            if (form is OrdersForm)
                            {
                                ((OrdersForm)form).UpdateOrders((Order[])action.Result);
                            }
                        }
                        break;

                    case Action.Types.UPDATE_POSITIONS:
                        foreach (var form in this.MdiChildren)
                        {
                            if (form is PositionsForm)
                            {
                                ((PositionsForm)form).UpdatePositions((Position[])action.Result);
                            }
                        }
                        break;

                    default:
                        Log.Error("Unhandled action result: " + action.Type);
                        break;
                }
            }
        }
        
        private void backgroundWorkerDataFeed_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;

            try
            {
                this.dataFeed.OnQuote += (_, quote) =>
                {
                    worker.ReportProgress(0, quote);
                };

                this.dataFeed.OnTrade += (_, trades) =>
                {
                    worker.ReportProgress(1, trades);
                };

                this.dataFeed.OnOrderBook += (_, book) =>
                {
                    worker.ReportProgress(2, book);
                };

                this.dataFeed.OnExecution += (_, execs) =>
                {
                    worker.ReportProgress(3, execs);
                };

                this.dataFeed.Start(this.symbol);
            }
            catch (Exception)
            {
                return;
            }

            while (!worker.CancellationPending)
            {
                Thread.Sleep(50);
            }

            this.dataFeed.Stop();
        }

        private void backgroundWorkerDataFeed_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                var quotes = (DataFeedQuoteEventArgs)e.UserState;

                foreach (var form in this.MdiChildren)
                {
                    if (form is OrderEntryForm)
                    {
                        ((OrderEntryForm)form).UpdateQuotes((DataFeedQuoteEventArgs)e.UserState);
                    }
                    else if (form is PositionsForm)
                    {
                        ((PositionsForm)form).UpdateQuotes((DataFeedQuoteEventArgs)e.UserState);
                    }
                }

                foreach (var quote in quotes.Quotes)
                {
                    if (quote.Symbol == this.symbol)
                    {
                        this.bidPrice = quote.Bid;
                        this.askPrice = quote.Ask;
                    }
                }

                this.updateStatusStrip();
            }
            else if (e.ProgressPercentage == 1)
            {
                foreach (var form in this.MdiChildren)
                {
                    if (form is ChartForm)
                    {
                        ((ChartForm)form).UpdateTrades((DataFeedTradeEventArgs)e.UserState);
                    }
                    else if (form is TradesForm)
                    {
                        ((TradesForm)form).UpdateTrades((DataFeedTradeEventArgs)e.UserState);
                    }
                }
            }
            else if (e.ProgressPercentage == 2)
            {
                foreach (var form in this.MdiChildren)
                {
                    if (form is OrderBookForm)
                    {
                        ((OrderBookForm)form).UpdateEntries((DataFeedOrderBookEventArgs)e.UserState);
                    }
                }
            }
            else if (e.ProgressPercentage == 3)
            {
                foreach (var exec in ((DataFeedExecutionEventArgs)e.UserState).Executions)
                {
                    Log.Info("Order filled: " + exec.ToString());
                }

                queueAction(new Action(Action.Types.UPDATE_POSITIONS));
                queueAction(new Action(Action.Types.UPDATE_ORDERS));
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            queueAction(new Action(Action.Types.UPDATE_POSITIONS));
            queueAction(new Action(Action.Types.UPDATE_ORDERS));
        }
    }
}
