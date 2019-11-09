using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AlphaTrade
{
    public partial class TradePlanForm : Form
    {
        public TradePlanForm()
        {
            InitializeComponent();
            Read();
        }

        private string Filename()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            return path + Path.DirectorySeparatorChar + "AlphaTrade.txt";
        }

        private void Read()
        {
            try
            {
                this.textBox1.Text = File.ReadAllText(Filename(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void Write()
        {
            try
            {
                File.WriteAllText(Filename(), this.textBox1.Text, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }

        private void TradePlanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Write();
        }
    }
}
