using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_1.Models
{
    internal class Logger
    {
        private readonly string _filePath;

        public Logger()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + "\\ClientsData\\Logs.json";

            if(!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        public void WriteLog(LogInfo logInfo)
        {
            TextReader text = File.OpenText(_filePath);
            JsonSerializer serializer = new JsonSerializer();
            List<LogInfo> logs = (List<LogInfo>)serializer.Deserialize(text, typeof(List<LogInfo>));
            text.Close();

            if (logs == null)
            {
                logs = new List<LogInfo>();
            }

            logs.Add(logInfo);

            using (StreamWriter file = File.CreateText(_filePath))
            {
                serializer.Serialize(file, logs);
            }
        }
    }
}
