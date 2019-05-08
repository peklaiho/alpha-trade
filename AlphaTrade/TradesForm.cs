using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class TradesForm : Form
    {
        private string symbol;

        private BindingList<Trade> data = new BindingList<Trade>();
        private int tradesInHistory = 20;

        public TradesForm(string symbol)
        {
            this.symbol = symbol;

            InitializeComponent();

            this.Text = symbol;
            this.dataGridViewTrades.DataSource = data;
        }

        public void UpdateTrades(DataFeedTradeEventArgs e)
        {
            foreach (var trade in e.Trades)
            {
                if (trade.Symbol == this.symbol)
                {
                    this.data.Add(trade);
                    if (data.Count > tradesInHistory)
                    {
                        data.RemoveAt(0);
                    }
                }
            }
        }

        private void dataGridViewTrades_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var trade = (Trade)this.dataGridViewTrades.Rows[e.RowIndex].DataBoundItem;

                if (trade.Direction > 0)
                {
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else if (trade.Direction < 0)
                {
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
            }
        }
    }
}
