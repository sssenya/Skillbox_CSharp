using System;

namespace Practice_12_1.Models
{
    internal class LogInfo
    {
        public DateTime Time { get; set; }
        public string AuthorName { get; set; }
        public string ClientName { get; set; }
        public string TransactionType { get; set; }
        public double TransactionSum { get; set; }
    }
}
