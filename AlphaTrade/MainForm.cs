using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class MainForm : Form
    {
        private IExchange exchange;
        private DataFeed dataFeed;
        private string symbol;

        private IList<Action> actionQueue = new List<Action>();
        private LogForm logForm;
        private int actionIndex = 0;

        private int lotSize = 1;
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
                    createOrder(Side.BUY, 1, 999);
                    return true;
                case Keys.Control | Keys.Down:
                    createOrder(Side.SELL, 1, 999);
                    return true;

                // Limit buys
                case Keys.Control | Keys.Add:
                    createOrder(Side.BUY, 1, 0);
                    return true;
                case Keys.Control | Keys.NumPad1:
                    createOrder(Side.BUY, 1, -1);
                    return true;
                case Keys.Control | Keys.NumPad2:
                    createOrder(Side.BUY, 1, -2);
                    return true;
                case Keys.Control | Keys.NumPad3:
                    createOrder(Side.BUY, 1, -3);
                    return true;

                // Limit sells
                case Keys.Control | Keys.Subtract:
                    createOrder(Side.SELL, 1, 0);
                    return true;
                case Keys.Control | Keys.NumPad7:
                    createOrder(Side.SELL, 1, +1);
                    return true;
                case Keys.Control | Keys.NumPad8:
                    createOrder(Side.SELL, 1, +2);
                    return true;
                case Keys.Control | Keys.NumPad9:
                    createOrder(Side.SELL, 1, +3);
                    return true;

                // Other
                case Keys.Control | Keys.NumPad0:
                    queueAction(new Action(Action.Types.CANCEL_ALL_ORDERS));
                    return true;
                case Keys.Control | Keys.Delete:
                    queueAction(new Action(Action.Types.CLOSE_ALL_POSITIONS));
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void queueAction(Action action)
        {
            this.actionQueue.Add(action);

            // Start next action
            if (!this.backgroundWorkerAction.IsBusy)
            {
                var next = this.actionQueue[this.actionIndex++];
                this.backgroundWorkerAction.RunWorkerAsync(next);
            }
        }

        private void createOrder(Side side, int lots, int relPrice)
        {
            var order = new Order() { Side = side, Size = lotSize * lots, Type = OrderType.LIMIT };

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

            Log.Info(order.ToString()); // TEMPORARY
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

        private void orderBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queueAction(new Action(Action.Types.WINDOW_ORDER_BOOK));
        }

        private void orderEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OrderEntryForm(this.symbol, this.bidPrice, this.askPrice);
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
                    case Action.Types.WINDOW_CHART:
                        action.Result = exchange.GetChart(symbol, (CandleSize) action.Args);
                        break;

                    case Action.Types.WINDOW_ORDER_BOOK:
                        action.Result = exchange.GetOrderBook(symbol);
                        break;
                }
            }
            catch (Exception ex)
            {
                action.Result = ex;
            }
        }

        private void backgroundWorkerAction_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Action action = (Action)e.Result;

            if (!(action.Result is Exception))
            { 
                switch (action.Type)
                {
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
                }
            }

            // Start next action
            if (this.actionQueue.Count > this.actionIndex)
            {
                var next = this.actionQueue[this.actionIndex++];
                this.backgroundWorkerAction.RunWorkerAsync(next);
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
        }
        #endregion
    }
}
