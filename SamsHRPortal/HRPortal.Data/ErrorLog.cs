using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Data
{
    public static class ErrorLog
    {
        private const string FILENAME = @"Datafiles\ErrorLog.txt";

        public static void Write(string message)
        {
            using (StreamWriter sw = File.AppendText(FILENAME))
            {
                sw.WriteLine(DateTime.Now + " " + message);
            }
        }
    }
}
