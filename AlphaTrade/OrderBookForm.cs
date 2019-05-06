using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class OrderBookForm : Form
    {
        private OrderBook data;
        private string symbol;

        private int orderBookLevels = 10;

        public OrderBookForm(OrderBook data, string symbol)
        {
            this.data = data;
            this.symbol = symbol;

            InitializeComponent();

            this.initGrid();
            this.Text = symbol;

            this.updateBook();
        }

        public void UpdateEntries(DataFeedOrderBookEventArgs e)
        {
            foreach (var entry in e.Entries)
            {
                if (entry.Symbol == this.symbol)
                {
                    if (e.Type == DataFeedOrderBookEventArgs.Types.Delete)
                    {
                        this.data.Delete(entry.Id);
                    }
                    else if (e.Type == DataFeedOrderBookEventArgs.Types.Insert)
                    {
                        this.data.Insert(entry.Id, entry.Size, entry.Price, entry.Side);
                    }
                    else
                    {
                        this.data.Update(entry.Id, entry.Size, entry.Side);
                    }
                }
            }

            this.updateBook();
        }

        private void initGrid()
        {
            for (int i = 0; i < orderBookLevels * 2; i++)
            {
                this.dataGridViewOrderBook.Rows.Add(null, null, null, null);

                if (i < orderBookLevels)
                {
                    this.dataGridViewOrderBook.Rows[i].DefaultCellStyle.BackColor = Color.Salmon;
                }
                else
                {
                    this.dataGridViewOrderBook.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                }
            }
        }

        private void updateBook()
        {
            var asks = this.data.GetBest(Side.SELL, orderBookLevels);
            var bids = this.data.GetBest(Side.BUY, orderBookLevels);

            for (int i = 0; i < orderBookLevels; i++)
            {
                var row = this.dataGridViewOrderBook.Rows[i];
                var entry = asks[orderBookLevels - i - 1];

                row.Cells[0].Value = null;
                row.Cells[1].Value = null;
                row.Cells[2].Value = entry != null ? entry.Price : 0;
                row.Cells[3].Value = entry != null ? entry.Size / 1000 : 0;
            }

            for (int i = 0; i < orderBookLevels; i++)
            {
                var row = this.dataGridViewOrderBook.Rows[orderBookLevels + i];
                var entry = bids[i];

                row.Cells[0].Value = entry != null ? entry.Size / 1000 : 0;
                row.Cells[1].Value = entry != null ? entry.Price : 0;
                row.Cells[2].Value = null;
                row.Cells[3].Value = null;
            }
        }
    }
}
