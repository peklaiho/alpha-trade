using System;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class OrderEntryForm : Form
    {
        public bool CloseOnEntry { get; set; }

        private string symbol;
        private double bidPrice;
        private double askPrice;

        public OrderEntryForm(string symbol, int lotSize, double tickSize)
        {
            this.symbol = symbol;

            InitializeComponent();

            this.Text = symbol;
            this.numericSize.Minimum = lotSize;
            this.numericSize.Increment = lotSize;
            this.numericPrice.Increment = (decimal)tickSize;
            OrderType = OrderType.LIMIT;

            this.updateBidAsk();
        }

        public OrderType OrderType
        {
            get
            {
                return (OrderType)this.comboType.SelectedIndex;
            }
            set
            {
                this.comboType.SelectedIndex = (int)value;
            }
        }

        public int OrderSize
        {
            get
            {
                return (int)this.numericSize.Value;
            }
            set
            {
                this.numericSize.Value = (int)value;
            }
        }

        public double OrderPrice
        {
            get
            {
                return (double)this.numericPrice.Value;
            }
            set
            {
                this.numericPrice.Value = (decimal)value;
            }
        }

        public bool BuyEnabled
        {
            get
            {
                return this.buttonBuy.Enabled;
            }
            set
            {
                this.buttonBuy.Enabled = value;
            }
        }

        public bool SellEnabled
        {
            get
            {
                return this.buttonSell.Enabled;
            }
            set
            {
                this.buttonSell.Enabled = value;
            }
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

        private void afterEntry()
        {
            if (CloseOnEntry)
            {
                this.Close();
            }
            else
            {
                // Reset order type and size
                // OrderType = OrderType.LIMIT;
                // this.numericSize.Value = this.numericSize.Minimum;
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            ((MainForm)this.MdiParent).CreateOrder(makeOrder(Side.BUY));
            afterEntry();
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            ((MainForm)this.MdiParent).CreateOrder(makeOrder(Side.SELL));
            afterEntry();
        }

        private Order makeOrder(Side side)
        {
            var order = new Order()
            {
                Symbol = symbol,
                Side = side,
                Type = (OrderType)this.comboType.SelectedIndex,
                Price = (double)this.numericPrice.Value,
                Size = (int)this.numericSize.Value,
            };
            order.Unfilled = order.Size;
            return order;
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
