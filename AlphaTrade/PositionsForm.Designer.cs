namespace AlphaTrade
{
    partial class PositionsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnPosSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosPnl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosClose = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPosSymbol,
            this.ColumnPosSize,
            this.ColumnPosPrice,
            this.ColumnPosPnl,
            this.ColumnPosClose});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(384, 111);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // ColumnPosSymbol
            // 
            this.ColumnPosSymbol.DataPropertyName = "Symbol";
            this.ColumnPosSymbol.HeaderText = "Symbol";
            this.ColumnPosSymbol.Name = "ColumnPosSymbol";
            this.ColumnPosSymbol.ReadOnly = true;
            // 
            // ColumnPosSize
            // 
            this.ColumnPosSize.DataPropertyName = "Size";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnPosSize.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnPosSize.HeaderText = "Size";
            this.ColumnPosSize.Name = "ColumnPosSize";
            this.ColumnPosSize.ReadOnly = true;
            // 
            // ColumnPosPrice
            // 
            this.ColumnPosPrice.DataPropertyName = "Price";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnPosPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnPosPrice.HeaderText = "Price";
            this.ColumnPosPrice.Name = "ColumnPosPrice";
            this.ColumnPosPrice.ReadOnly = true;
            // 
            // ColumnPosPnl
            // 
            this.ColumnPosPnl.DataPropertyName = "PNL";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnPosPnl.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnPosPnl.HeaderText = "P/L";
            this.ColumnPosPnl.Name = "ColumnPosPnl";
            this.ColumnPosPnl.ReadOnly = true;
            // 
            // ColumnPosClose
            // 
            this.ColumnPosClose.DataPropertyName = "CloseText";
            this.ColumnPosClose.HeaderText = "";
            this.ColumnPosClose.Name = "ColumnPosClose";
            this.ColumnPosClose.ReadOnly = true;
            this.ColumnPosClose.Text = "";
            // 
            // PositionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 100);
            this.Name = "PositionsForm";
            this.Text = "Positions";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosPnl;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnPosClose;
    }
}