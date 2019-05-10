using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class PositionsForm : Form
    {
        public PositionsForm(Position[] positions)
        {
            InitializeComponent();

            this.UpdatePositions(positions);
        }

        public void UpdatePositions(Position[] positions)
        {
            this.dataGridView1.Rows.Clear();

            foreach (var pos in positions)
            {
                this.dataGridView1.Rows.Add(
                    pos.Symbol,
                    pos.Size,
                    pos.Price,
                    0d,
                    "Close"
                );
            }
        }

        public void UpdateQuotes(DataFeedQuoteEventArgs quotes)
        {
            foreach (var quote in quotes.Quotes)
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    if ((string)row.Cells[0].Value == quote.Symbol)
                    {
                        int size = (int)row.Cells[1].Value;
                        double price = (double)row.Cells[2].Value;

                        if (size > 0)
                        {
                            row.Cells[3].Value = Util.PNLinUSD(size, price, quote.Ask);
                        }
                        else
                        {
                            row.Cells[3].Value = Util.PNLinUSD(size, price, quote.Bid);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var pnl = (double)this.dataGridView1.Rows[e.RowIndex].Cells[3].Value;

                if (pnl < 0)
                {
                    e.CellStyle.ForeColor = Color.OrangeRed;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.ForestGreen;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 4)
            {
                var symbol = (string)this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;

                ((MainForm)this.MdiParent).ClosePosition(symbol);
            }
        }
    }
}
