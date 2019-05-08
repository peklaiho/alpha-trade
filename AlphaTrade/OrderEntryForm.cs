using System;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class OrderEntryForm : Form
    {
        private string symbol;
        private double bidPrice;
        private double askPrice;

        public OrderEntryForm(string symbol, int lotSize, double tickSize, double bid, double ask)
        {
            this.symbol = symbol;
            this.bidPrice = bid;
            this.askPrice = ask;

            InitializeComponent();

            this.Text = symbol;
            this.numericSize.Minimum = (decimal)lotSize;
            this.numericSize.Increment = (decimal)lotSize;
            this.numericPrice.Increment = (decimal) tickSize;
            this.comboType.SelectedIndex = 0;

            this.updateBidAsk();
        }

        public void UpdateQuotes(DataFeedQuoteEventArgs quotes)
        {
            foreach (var quote in quotes.Quotes)
            {
                if (quote.Symbol == this.symbol)
                {
                    this.bidPrice = quote.Bid;
                    this.askPrice = quote.Ask;
                }
            }

            this.updateBidAsk();
        }

        private void updateBidAsk()
        {
            this.labelBid.Text = this.bidPrice.ToString("f2");
            this.labelAsk.Text = this.askPrice.ToString("f2");
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            ((MainForm)this.MdiParent).CreateOrder(makeOrder(Side.BUY));
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            ((MainForm)this.MdiParent).CreateOrder(makeOrder(Side.SELL));
        }

        private Order makeOrder(Side side)
        {
            return new Order()
            {
                Symbol = symbol,
                Side = side,
                Type = (OrderType)this.comboType.SelectedIndex,
                Price = (double)this.numericPrice.Value,
                Size = (int)this.numericSize.Value
            };
        }

        private void labelBid_Click(object sender, EventArgs e)
        {
            this.numericPrice.Value = (decimal) this.bidPrice;
        }

        private void labelAsk_Click(object sender, EventArgs e)
        {
            this.numericPrice.Value = (decimal) this.askPrice;
        }
    }
}
