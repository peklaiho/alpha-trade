using System;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class OrderEditForm : Form
    {
        private Order order;

        public OrderEditForm(Order order, int lotSize, double tickSize)
        {
            this.order = order;

            InitializeComponent();

            this.numericSize.Increment = lotSize;
            this.numericPrice.Increment = (decimal)tickSize;

            this.numericSize.Value = order.Size;
            this.numericPrice.Value = (decimal) order.Price;

            this.labelType.Text = order.TypeToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.order.Size = (int)this.numericSize.Value;
            this.order.Price = (double)this.numericPrice.Value;

            ((MainForm)this.MdiParent).ModifyOrder(this.order);
            this.Close();
        }
    }
}
