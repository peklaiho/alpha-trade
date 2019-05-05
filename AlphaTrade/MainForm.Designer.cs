namespace AlphaTrade
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getChartDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDataFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopDataFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMoreBarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLessBarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerChartData = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDataFeed = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewOrderBook = new System.Windows.Forms.DataGridView();
            this.dataGridViewTrades = new System.Windows.Forms.DataGridView();
            this.ColumnBidV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBidP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAskP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAskV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrades)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Interval = 10D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Interval = 10D;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY2.Interval = 10D;
            chartArea1.AxisY2.IsStartedFromZero = false;
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.MajorGrid.Interval = 10D;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.Interval = 10D;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(0, 27);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.White;
            series1.CustomProperties = "PriceDownColor=DarkOrange, PointWidth=0.7, PriceUpColor=ForestGreen";
            series1.Name = "Series1";
            series1.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(608, 534);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getChartDataToolStripMenuItem,
            this.startDataFeedToolStripMenuItem,
            this.stopDataFeedToolStripMenuItem,
            this.showMoreBarsToolStripMenuItem,
            this.showLessBarsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // getChartDataToolStripMenuItem
            // 
            this.getChartDataToolStripMenuItem.Name = "getChartDataToolStripMenuItem";
            this.getChartDataToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.getChartDataToolStripMenuItem.Text = "Get chart data";
            this.getChartDataToolStripMenuItem.Click += new System.EventHandler(this.getChartDataToolStripMenuItem_Click);
            // 
            // startDataFeedToolStripMenuItem
            // 
            this.startDataFeedToolStripMenuItem.Name = "startDataFeedToolStripMenuItem";
            this.startDataFeedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.startDataFeedToolStripMenuItem.Text = "Start data feed";
            this.startDataFeedToolStripMenuItem.Click += new System.EventHandler(this.startDataFeedToolStripMenuItem_Click);
            // 
            // stopDataFeedToolStripMenuItem
            // 
            this.stopDataFeedToolStripMenuItem.Name = "stopDataFeedToolStripMenuItem";
            this.stopDataFeedToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.stopDataFeedToolStripMenuItem.Text = "Stop data feed";
            this.stopDataFeedToolStripMenuItem.Click += new System.EventHandler(this.stopDataFeedToolStripMenuItem_Click);
            // 
            // showMoreBarsToolStripMenuItem
            // 
            this.showMoreBarsToolStripMenuItem.Name = "showMoreBarsToolStripMenuItem";
            this.showMoreBarsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.showMoreBarsToolStripMenuItem.Text = "Show more bars";
            this.showMoreBarsToolStripMenuItem.Click += new System.EventHandler(this.showMoreBarsToolStripMenuItem_Click);
            // 
            // showLessBarsToolStripMenuItem
            // 
            this.showLessBarsToolStripMenuItem.Name = "showLessBarsToolStripMenuItem";
            this.showLessBarsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.showLessBarsToolStripMenuItem.Text = "Show less bars";
            this.showLessBarsToolStripMenuItem.Click += new System.EventHandler(this.showLessBarsToolStripMenuItem_Click);
            // 
            // backgroundWorkerChartData
            // 
            this.backgroundWorkerChartData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerChartData_DoWork);
            this.backgroundWorkerChartData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerChartData_RunWorkerCompleted);
            // 
            // backgroundWorkerDataFeed
            // 
            this.backgroundWorkerDataFeed.WorkerReportsProgress = true;
            this.backgroundWorkerDataFeed.WorkerSupportsCancellation = true;
            this.backgroundWorkerDataFeed.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDataFeed_DoWork);
            this.backgroundWorkerDataFeed.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDataFeed_ProgressChanged);
            // 
            // dataGridViewOrderBook
            // 
            this.dataGridViewOrderBook.AllowUserToAddRows = false;
            this.dataGridViewOrderBook.AllowUserToDeleteRows = false;
            this.dataGridViewOrderBook.AllowUserToResizeColumns = false;
            this.dataGridViewOrderBook.AllowUserToResizeRows = false;
            this.dataGridViewOrderBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOrderBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrderBook.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrderBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOrderBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderBook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBidV,
            this.ColumnBidP,
            this.ColumnAskP,
            this.ColumnAskV});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOrderBook.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewOrderBook.Location = new System.Drawing.Point(610, 24);
            this.dataGridViewOrderBook.MultiSelect = false;
            this.dataGridViewOrderBook.Name = "dataGridViewOrderBook";
            this.dataGridViewOrderBook.ReadOnly = true;
            this.dataGridViewOrderBook.RowHeadersVisible = false;
            this.dataGridViewOrderBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderBook.Size = new System.Drawing.Size(252, 467);
            this.dataGridViewOrderBook.TabIndex = 2;
            // 
            // dataGridViewTrades
            // 
            this.dataGridViewTrades.AllowUserToAddRows = false;
            this.dataGridViewTrades.AllowUserToDeleteRows = false;
            this.dataGridViewTrades.AllowUserToResizeColumns = false;
            this.dataGridViewTrades.AllowUserToResizeRows = false;
            this.dataGridViewTrades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTrades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTrades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTrades.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTrades.Location = new System.Drawing.Point(861, 24);
            this.dataGridViewTrades.MultiSelect = false;
            this.dataGridViewTrades.Name = "dataGridViewTrades";
            this.dataGridViewTrades.ReadOnly = true;
            this.dataGridViewTrades.RowHeadersVisible = false;
            this.dataGridViewTrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTrades.Size = new System.Drawing.Size(123, 467);
            this.dataGridViewTrades.TabIndex = 3;
            this.dataGridViewTrades.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewTrades_CellFormatting);
            // 
            // ColumnBidV
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            this.ColumnBidV.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnBidV.HeaderText = "BidV";
            this.ColumnBidV.Name = "ColumnBidV";
            this.ColumnBidV.ReadOnly = true;
            // 
            // ColumnBidP
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N1";
            this.ColumnBidP.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnBidP.HeaderText = "BidP";
            this.ColumnBidP.Name = "ColumnBidP";
            this.ColumnBidP.ReadOnly = true;
            // 
            // ColumnAskP
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N1";
            this.ColumnAskP.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnAskP.HeaderText = "AskP";
            this.ColumnAskP.Name = "ColumnAskP";
            this.ColumnAskP.ReadOnly = true;
            // 
            // ColumnAskV
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "N0";
            this.ColumnAskV.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnAskV.HeaderText = "AskV";
            this.ColumnAskV.Name = "ColumnAskV";
            this.ColumnAskV.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Price";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "N1";
            dataGridViewCellStyle8.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column1.HeaderText = "Price";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "VolumeThousands";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column2.HeaderText = "Vol";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.dataGridViewTrades);
            this.Controls.Add(this.dataGridViewOrderBook);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "AlphaTrader";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getChartDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDataFeedToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerChartData;
        private System.Windows.Forms.ToolStripMenuItem stopDataFeedToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDataFeed;
        private System.Windows.Forms.DataGridView dataGridViewOrderBook;
        private System.Windows.Forms.ToolStripMenuItem showMoreBarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLessBarsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewTrades;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBidV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBidP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAskP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAskV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

