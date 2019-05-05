using System;
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
            string logFile = ConfigurationManager.AppSettings["logFile"];
            Log.Init(logFile);

            string url = ConfigurationManager.AppSettings["bitmexUrl"];
            string key = ConfigurationManager.AppSettings["bitmexKey"];
            string secret = ConfigurationManager.AppSettings["bitmexSecret"];
            string symbol = ConfigurationManager.AppSettings["symbol"];
            IExchange exchange = new BitMEX(url, key, secret, symbol);

            string wsUrl = ConfigurationManager.AppSettings["bitmexWs"];
            DataFeed feed = new BitMEXDataFeed(wsUrl, symbol);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(exchange, feed));
        }
    }
}
