namespace AlphaTrade
{
    partial class OrderBookForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewOrderBook = new System.Windows.Forms.DataGridView();
            this.ColumnBidV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBidP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAskP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAskV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderBook)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOrderBook
            // 
            this.dataGridViewOrderBook.AllowUserToAddRows = false;
            this.dataGridViewOrderBook.AllowUserToDeleteRows = false;
            this.dataGridViewOrderBook.AllowUserToResizeColumns = false;
            this.dataGridViewOrderBook.AllowUserToResizeRows = false;
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
            this.dataGridViewOrderBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOrderBook.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewOrderBook.MultiSelect = false;
            this.dataGridViewOrderBook.Name = "dataGridViewOrderBook";
            this.dataGridViewOrderBook.ReadOnly = true;
            this.dataGridViewOrderBook.RowHeadersVisible = false;
            this.dataGridViewOrderBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderBook.Size = new System.Drawing.Size(244, 481);
            this.dataGridViewOrderBook.TabIndex = 3;
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
            // OrderBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(244, 481);
            this.Controls.Add(this.dataGridViewOrderBook);
            this.MinimumSize = new System.Drawing.Size(200, 300);
            this.Name = "OrderBookForm";
            this.Text = "OrderBookForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOrderBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBidV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBidP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAskP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAskV;
    }
}