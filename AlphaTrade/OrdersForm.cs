using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class OrdersForm : Form
    {
        private int lotSize;
        private double tickSize;

        public OrdersForm(Order[] orders, int lotSize, double tickSize)
        {
            this.lotSize = lotSize;
            this.tickSize = tickSize;

            InitializeComponent();

            UpdateOrders(orders);
        }

        public void UpdateOrders(Order[] orders)
        {
            this.dataGridView1.Rows.Clear();

            foreach (var order in orders)
            {
                string sizeStr = order.Size.ToString();
                if (order.Unfilled < order.Size)
                {
                    var filled = order.Size - order.Unfilled;
                    sizeStr = filled + " / " + order.Size;
                }

                this.dataGridView1.Rows.Add(
                    order,
                    order.Symbol,
                    order.TypeToString(),
                    sizeStr,
                    order.Price,
                    "Cancel"
                );
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var order = (Order)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                if (order.Type == OrderType.STOP)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else if (order.Side == Side.BUY)
                {
                    e.CellStyle.ForeColor = Color.ForestGreen;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
            {
                var order = (Order)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                ((MainForm)this.MdiParent).CancelOrder(order);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                var order = (Order)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                var form = new OrderEditForm(order, lotSize, tickSize);
                form.Location = new Point(Location.X, Location.Y);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
        }
    }
}
