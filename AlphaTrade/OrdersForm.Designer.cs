namespace AlphaTrade
{
    partial class OrdersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnOrdOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrdSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrdType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrdSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrdPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrdCancel = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.ColumnOrdOrder,
            this.ColumnOrdSymbol,
            this.ColumnOrdType,
            this.ColumnOrdSize,
            this.ColumnOrdPrice,
            this.ColumnOrdCancel});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(434, 111);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // ColumnOrdOrder
            // 
            this.ColumnOrdOrder.HeaderText = "Order";
            this.ColumnOrdOrder.Name = "ColumnOrdOrder";
            this.ColumnOrdOrder.ReadOnly = true;
            this.ColumnOrdOrder.Visible = false;
            // 
            // ColumnOrdSymbol
            // 
            this.ColumnOrdSymbol.HeaderText = "Symbol";
            this.ColumnOrdSymbol.Name = "ColumnOrdSymbol";
            this.ColumnOrdSymbol.ReadOnly = true;
            // 
            // ColumnOrdType
            // 
            this.ColumnOrdType.HeaderText = "Type";
            this.ColumnOrdType.Name = "ColumnOrdType";
            this.ColumnOrdType.ReadOnly = true;
            // 
            // ColumnOrdSize
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnOrdSize.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnOrdSize.HeaderText = "Size";
            this.ColumnOrdSize.Name = "ColumnOrdSize";
            this.ColumnOrdSize.ReadOnly = true;
            // 
            // ColumnOrdPrice
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnOrdPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnOrdPrice.HeaderText = "Price";
            this.ColumnOrdPrice.Name = "ColumnOrdPrice";
            this.ColumnOrdPrice.ReadOnly = true;
            // 
            // ColumnOrdCancel
            // 
            this.ColumnOrdCancel.HeaderText = "";
            this.ColumnOrdCancel.Name = "ColumnOrdCancel";
            this.ColumnOrdCancel.ReadOnly = true;
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(434, 111);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 100);
            this.Name = "OrdersForm";
            this.Text = "Orders";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrdOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrdSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrdType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrdSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrdPrice;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnOrdCancel;
    }
}