using System;

namespace AlphaTrade
{
    public class LogEntry
    {
        public DateTime Time = DateTime.Now;
        public string Level;
        public string Message;

        public override string ToString()
        {
            return Time.ToString("HH:mm:ss") + " [" + Level + "] " + Message;
        }
    }
}
