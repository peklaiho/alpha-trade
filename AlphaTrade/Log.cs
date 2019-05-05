using System;
using System.IO;

namespace AlphaTrade
{
    public static class Log
    {
        private static StreamWriter log;

        public static void Init(string file)
        {
            log = new StreamWriter(file, true);
            Info("Starting AlphaTrade");
        }

        public static void Debug(string txt)
        {
            // write("D", txt);
        }

        public static void Info(string txt)
        {
            write("I", txt);
        }

        public static void Warn(string txt)
        {
            write("W", txt);
        }

        public static void Error(string txt)
        {
            write("E", txt);
        }

        private static void write(string level, string txt)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            log.WriteLine(time + " :: " + level + " :: " + txt);
            log.Flush();
        }
    }
}
