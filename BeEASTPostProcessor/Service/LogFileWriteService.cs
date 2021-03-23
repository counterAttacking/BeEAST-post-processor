using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Service
{
    public class LogFileWriteService
    {
        private Exception exception;

        public LogFileWriteService(Exception exception)
        {
            this.exception = exception;
        }

        public void MakeLogFile()
        {
            var msg = new StringBuilder();
            msg.Append(this.exception.ToString());

            var fileName = new StringBuilder();
            fileName.Append(DateTime.Now.ToString("yyyyMMddhhmmss"));
            fileName.Append("_log.txt");

            var filePath = Path.Combine(Environment.CurrentDirectory, "log", fileName.ToString());
            File.WriteAllText(filePath, msg.ToString());
        }
    }
}
