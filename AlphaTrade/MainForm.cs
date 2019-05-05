using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class MainForm : Form
    {
        private IExchange exchange;
        private DataFeed dataFeed;

        private ChartData chartData;
        private OrderBook orderBook;
        private BindingList<DataFeedTrade> tradeHistory = new BindingList<DataFeedTrade>();

        private int shownCandles = 100;
        private int orderBookLevels = 10;
        private int tradesInHistory = 20;
        private int lotSize = 1;

        public MainForm(IExchange exchange, DataFeed dataFeed)
        {
            this.exchange = exchange;
            this.dataFeed = dataFeed;

            this.chartData = new ChartData(300);
            this.orderBook = new OrderBook();

            InitializeComponent();
            this.initBook();
            this.dataGridViewTrades.DataSource = this.tradeHistory;
        }

        private void initBook()
        {
            for (int i = 0; i < orderBookLevels * 2; i++)
            {
                this.dataGridViewOrderBook.Rows.Add(null, null, null, null);

                if (i < orderBookLevels)
                {
                    this.dataGridViewOrderBook.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                }
                else
                {
                    this.dataGridViewOrderBook.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                }
            }
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
                    actionCancelOrders();
                    return true;
                case Keys.Control | Keys.Delete:
                    actionCancelPositions();
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #region Actions
        private void actionCancelOrders()
        {
            Log.Info("Cancel all orders.");
        }
        private void actionCancelPositions()
        {
            Log.Info("Cancel all positions.");
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
                    order.Price = orderBook.GetBid() + relPrice;
                }
                else
                {
                    order.Price = orderBook.GetAsk() + relPrice;
                }
            }

            Log.Info(order.ToString());
        }
        #endregion

        #region View
        private void updateChart()
        {
            var seriesData = this.chart1.Series[0].Points;
            var candles = this.chartData.GetCandles();
            int min = 0, max = 0;

            // Update candle series
            seriesData.Clear();
            for (int i = candles.Count - shownCandles; i < candles.Count; i++)
            {
                var candle = candles[i];

                seriesData.AddXY(
                    candle.EndTime,
                    candle.High,
                    candle.Low,
                    candle.Open,
                    candle.Close
                );

                if (min == 0 || candle.Low < min)
                {
                    min = (int)candle.Low;
                }
                if (max == 0 || candle.High > max)
                {
                    max = (int)candle.High;
                }
            }

            // Set min/max for y-axis
            min = min - 3;
            max = max + 3;
            while (min % 10 != 0) min--;
            while (max % 10 != 0) max++;
            this.chart1.ChartAreas[0].AxisY2.Minimum = min;
            this.chart1.ChartAreas[0].AxisY2.Maximum = max;

            this.chart1.Update();
        }

        private void updateBook()
        {
            var asks = this.orderBook.GetBest(Side.SELL, orderBookLevels);
            var bids = this.orderBook.GetBest(Side.BUY, orderBookLevels);

            for (int i = 0; i < orderBookLevels; i++)
            {
                var row = this.dataGridViewOrderBook.Rows[i];
                var entry = asks[orderBookLevels - i - 1];

                row.Cells[0].Value = null;
                row.Cells[1].Value = null;
                row.Cells[2].Value = entry != null ? entry.Price : 0;
                row.Cells[3].Value = entry != null ? entry.Size / 1000 : 0;
            }

            for (int i = 0; i < orderBookLevels; i++)
            {
                var row = this.dataGridViewOrderBook.Rows[orderBookLevels + i];
                var entry = bids[i];

                row.Cells[0].Value = entry != null ? entry.Size / 1000 : 0;
                row.Cells[1].Value = entry != null ? entry.Price : 0;
                row.Cells[2].Value = null;
                row.Cells[3].Value = null;
            }
        }

        private void dataGridViewTrades_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var trade = (DataFeedTrade) this.dataGridViewTrades.Rows[e.RowIndex].DataBoundItem;

                if (trade.Direction > 0)
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else if (trade.Direction < 0)
                {
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
            }
        }
        #endregion

        #region Menu
        private void getChartDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.backgroundWorkerChartData.IsBusy)
            {
                this.backgroundWorkerChartData.RunWorkerAsync();
            }
        }

        private void startDataFeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.backgroundWorkerDataFeed.IsBusy)
            {
                this.orderBook.Clear();
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

        private void showMoreBarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.shownCandles < 300)
            {
                this.shownCandles += 50;
                updateChart();
            }
        }

        private void showLessBarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.shownCandles > 50)
            {
                this.shownCandles -= 50;
                this.updateChart();
            }
        }
        #endregion

        #region BackgroundWorkers
        private void backgroundWorkerChartData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Log.Info("Fetch chart data.");
                exchange.GetChart(chartData);
                e.Result = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void backgroundWorkerChartData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                this.updateChart();
            }
        }
        
        private void backgroundWorkerDataFeed_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;

            try
            {
                Log.Info("Start data feed.");

                this.dataFeed.OnTrade += (_, trades) =>
                {
                    worker.ReportProgress(0, trades);
                };

                this.dataFeed.OnOrderBook += (_, book) =>
                {
                    worker.ReportProgress(1, book);
                };

                this.dataFeed.Start();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return;
            }

            while (!worker.CancellationPending)
            {
                Thread.Sleep(50);
            }

            try
            {
                Log.Info("Stop data feed.");
                this.dataFeed.Stop();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void backgroundWorkerDataFeed_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                foreach (var trade in ((DataFeedTradeEventArgs)e.UserState).Trades)
                {
                    this.chartData.Update(trade.Time, trade.Price, trade.Volume);

                    this.tradeHistory.Add(trade);
                    if (tradeHistory.Count > tradesInHistory)
                    {
                        tradeHistory.RemoveAt(0);
                    }
                }

                this.updateChart();
            }
            else if (e.ProgressPercentage == 1)
            {
                var bookData = ((DataFeedOrderBookEventArgs)e.UserState);

                foreach (var entry in bookData.Entries)
                {
                    switch (bookData.Type)
                    {
                        case DataFeedOrderBookEventArgs.Types.Delete:
                            this.orderBook.Delete(entry.Id);
                            break;
                        case DataFeedOrderBookEventArgs.Types.Insert:
                            this.orderBook.Insert(entry.Id, entry.Size, entry.Price, entry.Side);
                            break;
                        case DataFeedOrderBookEventArgs.Types.Update:
                            this.orderBook.Update(entry.Id, entry.Size, entry.Side);
                            break;
                    }
                }

                this.updateBook();
            }
        }
        #endregion
    }
}
