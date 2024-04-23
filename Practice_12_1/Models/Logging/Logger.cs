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
        private readonly JsonConverter<LogInfo> _converter;

        public Logger()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + "\\ClientsData\\Logs.json";

            if(!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }

            _converter = new JsonConverter<LogInfo>(_filePath);
        }

        public void WriteLog(LogInfo logInfo)
        {
            List<LogInfo> logs = _converter.GetElements() ?? new List<LogInfo>();
            logs.Add(logInfo);

            _converter.UpdateElements(logs);
        }
    }
}
