using System;
using System.IO;

namespace AlphaTrade
{
    class Filesystem
    {
        public static string GetLogFile()
        {
            string logDir = GetDataFolder() + Path.DirectorySeparatorChar + "log";

            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            string filename = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            return logDir + Path.DirectorySeparatorChar + filename;
        }

        private static string GetDataFolder()
        {
            string dataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "AlphaTrade";

            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            return dataDir;
        }
    }
}
