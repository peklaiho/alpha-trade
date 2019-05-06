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

        private void updateChart()
        {
            var seriesData = this.chart1.Series[0].Points;
            var candles = this.data.GetCandles();
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
    }
}
