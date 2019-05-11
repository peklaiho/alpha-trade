using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlphaTrade
{
    public partial class ChartForm : Form
    {
        private ChartData data;
        private string symbol;
        private int lotSize;
        private double tickSize;

        private int shownCandles = 100;
        private Position currentPosition = null;

        public ChartForm(ChartData data, string symbol, int lotSize, double tickSize)
        {
            this.data = data;
            this.symbol = symbol;
            this.lotSize = lotSize;
            this.tickSize = tickSize;

            InitializeComponent();

            this.chart1.MouseWheel += Chart1_MouseWheel;

            this.updateTitle();
            this.updateChart();
        }

        public void UpdateTrades(DataFeedTradeEventArgs e)
        {
            foreach (var trade in e.Trades)
            {
                if (trade.Symbol == this.symbol)
                {
                    this.data.Update(trade.Time, trade.Price, trade.Volume);
                }
            }

            this.updateChart();
        }

        public void UpdatePositions(Position[] positions)
        {
            currentPosition = null;

            foreach (var pos in positions)
            {
                if (pos.Symbol == symbol)
                {
                    currentPosition = pos;
                    break;
                }
            }
        }

        private void updateTitle()
        {
            this.Text = symbol + " (" + Util.CandleSizeToString(data.GetCandleSize()) + ")";
        }

        private void updateChart()
        {
            var candles = this.data.GetCandles();
            var ma200Data = this.data.SMA(200);
            var ma20Data = this.data.SMA(20);
            var ma8Data = this.data.SMA(8);

            var price = this.chart1.Series["Price"].Points;
            var ma200 = this.chart1.Series["MA200"].Points;
            var ma20 = this.chart1.Series["MA20"].Points;
            var ma8 = this.chart1.Series["MA8"].Points;

            price.Clear();
            ma200.Clear();
            ma20.Clear();
            ma8.Clear();

            int min = 0, max = 0;

            for (int i = candles.Count - shownCandles; i < candles.Count; i++)
            {
                var candle = candles[i];

                // Update price
                price.AddXY(
                    candle.EndTime,
                    candle.High,
                    candle.Low,
                    candle.Open,
                    candle.Close
                );

                // Update MAs
                ma200.AddXY(candle.EndTime, ma200Data[i]);
                ma20.AddXY(candle.EndTime, ma20Data[i]);
                // ma8.AddXY(candle.EndTime, ma8Data[i]);

                // Record min/max
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
            int interval = this.chartInterval();
            min = min - 3;
            max = max + 3;
            while (min % interval != 0) min--;
            while (max % interval != 0) max++;
            this.chart1.ChartAreas[0].AxisY2.Minimum = min;
            this.chart1.ChartAreas[0].AxisY2.Maximum = max;
            this.chart1.ChartAreas[0].AxisY2.Interval = interval;
            this.chart1.ChartAreas[0].AxisY2.MajorGrid.Interval = interval;

            this.chart1.Update();
        }

        private int chartInterval()
        {
            switch (this.data.GetCandleSize())
            {
                case CandleSize.DAY_1:
                    return 200;
                case CandleSize.HOUR_1:
                    return 50;
                case CandleSize.MIN_1:
                    return 10;
                default:
                    return 20;
            }
        }

        private void Chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (shownCandles < 300)
                {
                    shownCandles += 10;
                    updateChart();
                }
            }
            else if (e.Delta < 0)
            {
                if (shownCandles > 30)
                {
                    shownCandles -= 10;
                    updateChart();
                }
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var result = chart1.HitTest(e.X, e.Y);

            if (result.PointIndex >= 0)
            {
                var high = this.chart1.Series["Price"].Points[result.PointIndex].YValues[0];
                var low = this.chart1.Series["Price"].Points[result.PointIndex].YValues[1];
                var open = this.chart1.Series["Price"].Points[result.PointIndex].YValues[2];
                var close = this.chart1.Series["Price"].Points[result.PointIndex].YValues[3];

                this.labelPrice.Text = String.Format("Open: {0:F2}  High: {1:F2}  Low:  {2:F2}  Close: {3:F2}", open, high, low, close);
            }
        }

        private void chart1_MouseLeave(object sender, EventArgs e)
        {
            this.labelPrice.Text = "";
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var result = chart1.HitTest(e.X, e.Y);

            if (result.PointIndex >= 0 && currentPosition != null)
            {
                var high = this.chart1.Series["Price"].Points[result.PointIndex].YValues[0];
                var low = this.chart1.Series["Price"].Points[result.PointIndex].YValues[1];

                var form = new OrderEntryForm(symbol, lotSize, tickSize);
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(Location.X + e.X, Location.Y + e.Y);
                form.MdiParent = this.MdiParent;
                form.CloseOnEntry = true;
                form.OrderType = OrderType.STOP;
                form.OrderSize = Math.Abs(currentPosition.Size);

                if (currentPosition.Size > 0)
                {
                    // we are long, place a stop sell one tick below low of this candle
                    form.OrderPrice = low - tickSize;
                    form.BuyEnabled = false;
                }
                else
                {
                    // we are short, place a stop buy one tick above high of this candle
                    form.OrderPrice = high + tickSize;
                    form.SellEnabled = false;
                }

                form.Show();
            }
        }
    }
}
