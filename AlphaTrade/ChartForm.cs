using System;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class ChartForm : Form
    {
        private ChartData data;
        private string symbol;
        private int shownCandles = 100;

        public ChartForm(ChartData data, string symbol)
        {
            this.data = data;
            this.symbol = symbol;

            InitializeComponent();

            this.Text = symbol + " (" + Util.CandleSizeToString(data.GetCandleSize()) + ")";

            this.chart1.MouseWheel += Chart1_MouseWheel;

            this.updateChart();
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
                    return 5;
                default:
                    return 10;
            }
        }
    }
}
