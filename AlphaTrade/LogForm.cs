using System;
using System.Windows.Forms;

namespace AlphaTrade
{
    public partial class LogForm : Form
    {
        private int index = 0;

        public LogForm()
        {
            InitializeComponent();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var startIndex = index;

            for (; index < Log.Entries.Count; index++)
            {
                if (index > 0)
                {
                    this.textBox1.AppendText("\r\n");
                }
                this.textBox1.AppendText(Log.Entries[index].ToString());
            }

            // Scroll to bottom if we added new rows
            if (index > startIndex)
            {
                // this.textBox1.scr
            }
        }
    }
}
