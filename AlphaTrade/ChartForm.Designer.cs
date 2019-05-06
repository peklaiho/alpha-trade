namespace AlphaTrade
{
    partial class ChartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.IsStartedFromZero = false;
            chartArea3.AxisX.LabelStyle.Enabled = false;
            chartArea3.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.Interval = 10D;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.AxisY.MajorTickMark.Interval = 10D;
            chartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY2.Interval = 10D;
            chartArea3.AxisY2.IsStartedFromZero = false;
            chartArea3.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.LightGray;
            chartArea3.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea3.AxisY2.MajorGrid.Interval = 10D;
            chartArea3.AxisY2.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea3.AxisY2.MajorTickMark.Enabled = false;
            chartArea3.AxisY2.MajorTickMark.Interval = 10D;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Color = System.Drawing.Color.White;
            series3.CustomProperties = "PriceDownColor=DarkOrange, PointWidth=0.7, PriceUpColor=ForestGreen";
            series3.Name = "Series1";
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series3.YValuesPerPoint = 4;
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(784, 361);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.chart1);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}