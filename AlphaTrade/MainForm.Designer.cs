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
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerAction = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDataFeed = new System.ComponentModel.BackgroundWorker();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.startDataFeedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startDataFeedToolStripMenuItem.Text = "Start Data Feed";
            this.startDataFeedToolStripMenuItem.Click += new System.EventHandler(this.startDataFeedToolStripMenuItem_Click);
            // 
            // stopDataFeedToolStripMenuItem
            // 
            this.stopDataFeedToolStripMenuItem.Name = "stopDataFeedToolStripMenuItem";
            this.stopDataFeedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopDataFeedToolStripMenuItem.Text = "Stop Data Feed";
            this.stopDataFeedToolStripMenuItem.Click += new System.EventHandler(this.stopDataFeedToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartToolStripMenuItem,
            this.orderBookToolStripMenuItem,
            this.orderEntryToolStripMenuItem,
            this.tradesToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.chartToolStripMenuItem.Text = "Chart";
            this.chartToolStripMenuItem.Click += new System.EventHandler(this.chartToolStripMenuItem_Click);
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
            // tradesToolStripMenuItem
            // 
            this.tradesToolStripMenuItem.Name = "tradesToolStripMenuItem";
            this.tradesToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.tradesToolStripMenuItem.Text = "Trades";
            this.tradesToolStripMenuItem.Click += new System.EventHandler(this.tradesToolStripMenuItem_Click);
            // 
            // backgroundWorkerAction
            // 
            this.backgroundWorkerAction.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAction_DoWork);
            this.backgroundWorkerAction.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAction_RunWorkerCompleted);
            // 
            // backgroundWorkerDataFeed
            // 
            this.backgroundWorkerDataFeed.WorkerReportsProgress = true;
            this.backgroundWorkerDataFeed.WorkerSupportsCancellation = true;
            this.backgroundWorkerDataFeed.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDataFeed_DoWork);
            this.backgroundWorkerDataFeed.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDataFeed_ProgressChanged);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Exit";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDataFeedToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAction;
        private System.Windows.Forms.ToolStripMenuItem stopDataFeedToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDataFeed;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

