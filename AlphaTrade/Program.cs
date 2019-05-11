using System;
using System.Net;
using System.Configuration;
using System.Windows.Forms;

namespace AlphaTrade
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServicePointManager.DefaultConnectionLimit = 5;

            Log.Init();

            string url = ConfigurationManager.AppSettings["bitmexUrl"];
            string key = ConfigurationManager.AppSettings["bitmexKey"];
            string secret = ConfigurationManager.AppSettings["bitmexSecret"];
            string symbol = ConfigurationManager.AppSettings["symbol"];
            IExchange exchange = new BitMEX(url, key, secret);

            string wsUrl = ConfigurationManager.AppSettings["bitmexWs"];
            DataFeed feed = new BitMEXDataFeed(wsUrl, key, secret);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(exchange, feed, symbol));
        }
    }
}
