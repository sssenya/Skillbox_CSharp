using System.Collections.Generic;

namespace Practice_12_1.Models
{
    internal class Logger : BaseRepository<LogInfo>
    {
        public Logger() : base("\\ClientsData\\Logs.json") { }

        public void WriteLog(LogInfo logInfo)
        {
            List<LogInfo> logs = _converter.GetElements() ?? new List<LogInfo>();
            logs.Add(logInfo);

            _converter.UpdateElements(logs);
        }
    }
}
