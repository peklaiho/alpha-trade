using System;
using System.Collections.Generic;
using System.IO;

namespace AlphaTrade
{
    public static class Log
    {
        public static IList<LogEntry> Entries = new List<LogEntry>();

        private static StreamWriter log;

        public static void Init()
        {
            string file = Filesystem.GetLogFile();
            log = new StreamWriter(file, true);
            Info("Welcome to AlphaTrade. Lets make some money!");
        }

        public static void Network(string txt)
        {
            record(new LogEntry() { Level = "N", Message = txt }, false);
        }

        public static void Debug(string txt)
        {
            record(new LogEntry() { Level = "D", Message = txt }, false);
        }

        public static void Info(string txt)
        {
            record(new LogEntry() { Level = "I", Message = txt });
        }

        public static void Warn(string txt)
        {
            record(new LogEntry() { Level = "W", Message = txt });
        }

        public static void Error(string txt)
        {
            record(new LogEntry() { Level = "E", Message = txt });
        }

        private static void record(LogEntry entry, bool addEntry = true)
        {
            if (addEntry)
                Entries.Add(entry);

            string time = entry.Time.ToString("yyyy-MM-dd HH:mm:ss");
            log.WriteLine(time + " :: " + entry.Level + " :: " + entry.Message);
            log.Flush();
        }
    }
}
