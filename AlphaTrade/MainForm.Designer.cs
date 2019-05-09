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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDataFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopDataFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.orderBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ordersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerDataFeed = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDataFeedToolStripMenuItem,
            this.stopDataFeedToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.menuToolStripMenuItem.Text = "Main";
            // 
            // startDataFeedToolStripMenuItem
            // 
            this.startDataFeedToolStripMenuItem.Name = "startDataFeedToolStripMenuItem";
            this.startDataFeedToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.startDataFeedToolStripMenuItem.Text = "Start Data Feed";
            this.startDataFeedToolStripMenuItem.Click += new System.EventHandler(this.startDataFeedToolStripMenuItem_Click);
            // 
            // stopDataFeedToolStripMenuItem
            // 
            this.stopDataFeedToolStripMenuItem.Name = "stopDataFeedToolStripMenuItem";
            this.stopDataFeedToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.stopDataFeedToolStripMenuItem.Text = "Stop Data Feed";
            this.stopDataFeedToolStripMenuItem.Click += new System.EventHandler(this.stopDataFeedToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartToolStripMenuItem,
            this.orderBookToolStripMenuItem,
            this.orderEntryToolStripMenuItem,
            this.positionsToolStripMenuItem,
            this.ordersToolStripMenuItem,
            this.tradesToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyToolStripMenuItem,
            this.hourlyToolStripMenuItem,
            this.minToolStripMenuItem,
            this.minToolStripMenuItem1});
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.chartToolStripMenuItem.Text = "Chart";
            // 
            // dailyToolStripMenuItem
            // 
            this.dailyToolStripMenuItem.Name = "dailyToolStripMenuItem";
            this.dailyToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.dailyToolStripMenuItem.Text = "Daily";
            this.dailyToolStripMenuItem.Click += new System.EventHandler(this.dailyToolStripMenuItem_Click);
            // 
            // hourlyToolStripMenuItem
            // 
            this.hourlyToolStripMenuItem.Name = "hourlyToolStripMenuItem";
            this.hourlyToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.hourlyToolStripMenuItem.Text = "Hourly";
            this.hourlyToolStripMenuItem.Click += new System.EventHandler(this.hourlyToolStripMenuItem_Click);
            // 
            // minToolStripMenuItem
            // 
            this.minToolStripMenuItem.Name = "minToolStripMenuItem";
            this.minToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.minToolStripMenuItem.Text = "5 Min";
            this.minToolStripMenuItem.Click += new System.EventHandler(this.min5ToolStripMenuItem_Click);
            // 
            // minToolStripMenuItem1
            // 
            this.minToolStripMenuItem1.Name = "minToolStripMenuItem1";
            this.minToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.minToolStripMenuItem1.Text = "1 Min";
            this.minToolStripMenuItem1.Click += new System.EventHandler(this.min1ToolStripMenuItem_Click);
            // 
            // orderBookToolStripMenuItem
            // 
            this.orderBookToolStripMenuItem.Name = "orderBookToolStripMenuItem";
            this.orderBookToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.orderBookToolStripMenuItem.Text = "Order Book";
            this.orderBookToolStripMenuItem.Click += new System.EventHandler(this.orderBookToolStripMenuItem_Click);
            // 
            // orderEntryToolStripMenuItem
            // 
            this.orderEntryToolStripMenuItem.Name = "orderEntryToolStripMenuItem";
            this.orderEntryToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.orderEntryToolStripMenuItem.Text = "Order Entry";
            this.orderEntryToolStripMenuItem.Click += new System.EventHandler(this.orderEntryToolStripMenuItem_Click);
            // 
            // positionsToolStripMenuItem
            // 
            this.positionsToolStripMenuItem.Name = "positionsToolStripMenuItem";
            this.positionsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.positionsToolStripMenuItem.Text = "Positions";
            this.positionsToolStripMenuItem.Click += new System.EventHandler(this.positionsToolStripMenuItem_Click);
            // 
            // ordersToolStripMenuItem
            // 
            this.ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            this.ordersToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.ordersToolStripMenuItem.Text = "Orders";
            this.ordersToolStripMenuItem.Click += new System.EventHandler(this.ordersToolStripMenuItem_Click);
            // 
            // tradesToolStripMenuItem
            // 
            this.tradesToolStripMenuItem.Name = "tradesToolStripMenuItem";
            this.tradesToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.tradesToolStripMenuItem.Text = "Trades";
            this.tradesToolStripMenuItem.Click += new System.EventHandler(this.tradesToolStripMenuItem_Click);
            // 
            // backgroundWorkerDataFeed
            // 
            this.backgroundWorkerDataFeed.WorkerReportsProgress = true;
            this.backgroundWorkerDataFeed.WorkerSupportsCancellation = true;
            this.backgroundWorkerDataFeed.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDataFeed_DoWork);
            this.backgroundWorkerDataFeed.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDataFeed_ProgressChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "AlphaTrader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDataFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopDataFeedToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDataFeed;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ToolStripMenuItem positionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ordersToolStripMenuItem;
    }
}

