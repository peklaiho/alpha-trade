using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class OrdersForm : Form
    {
        public OrdersForm(Order[] orders)
        {
            InitializeComponent();

            UpdateOrders(orders);
        }

        public void UpdateOrders(Order[] orders)
        {
            this.dataGridView1.Rows.Clear();

            foreach (var order in orders)
            {
                this.dataGridView1.Rows.Add(
                    order.Id,
                    order.Symbol,
                    order.TypeToString(),
                    order.Size,
                    order.Price,
                    "Cancel"
                );
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var type = (string)this.dataGridView1.Rows[e.RowIndex].Cells[2].Value;

                if (type.IndexOf("STOP") >= 0)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else if (type.IndexOf("BUY") >= 0)
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
            if (e.ColumnIndex == 5)
            {
                var id = (string)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                ((MainForm)this.MdiParent).CancelOrder(id);
            }
        }
    }
}
