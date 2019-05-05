using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
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

        private void updateChart()
        {
            var seriesData = this.chart1.Series[0].Points;
            var candles = this.chartData.GetCandles();
            var minMax = this.chartData.GetMinMax(shownCandles);

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
            }

            // Update min/max
            int min = (int)minMax.Item1 - 3;
            int max = (int)minMax.Item2 + 3;
            while (min % 10 != 0) min--;
            while (max % 10 != 0) max++;
            this.chart1.ChartAreas[0].AxisY2.Minimum = min;
            this.chart1.ChartAreas[0].AxisY2.Maximum = max;

            this.chart1.Update();
        }

        private void updateBook()
        {
            var asks = this.orderBook.GetBest(Side.ASK, orderBookLevels);
            var bids = this.orderBook.GetBest(Side.BID, orderBookLevels);

            for (int i = 0; i < orderBookLevels; i++)
            {
                var row = this.dataGridViewOrderBook.Rows[i];
                row.Cells[0].Value = null;
                row.Cells[1].Value = null;
                row.Cells[2].Value = asks[orderBookLevels - i - 1].Price;
                row.Cells[3].Value = asks[orderBookLevels - i - 1].Size / 1000;
            }

            for (int i = 0; i < orderBookLevels; i++)
            {
                var row = this.dataGridViewOrderBook.Rows[orderBookLevels + i];
                row.Cells[0].Value = bids[i].Size / 1000;
                row.Cells[1].Value = bids[i].Price;
                row.Cells[2].Value = null;
                row.Cells[3].Value = null;
            }
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
                Log.Info("Fetch chart data");
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
                Log.Info("Start data feed");

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
                Log.Info("Stop data feed");
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
