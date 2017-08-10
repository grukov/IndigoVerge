using IndigoVergeTask.Contracts;
using System;
using System.IO;
using System.Reflection;

namespace IndigoVergeTask.Providers
{
    public class FileLogger : ILogger
    {
        public void Log(string msg)
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(assemblyFolder, "Errors.txt");

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                var currentDateTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"); // Bad idea, I know!
                string errorMessage = string.Format("{0} - {1}", currentDateTime, msg);
                sw.WriteLine(errorMessage);
            }
        }
    }
}
