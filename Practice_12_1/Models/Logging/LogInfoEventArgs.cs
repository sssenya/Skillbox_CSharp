using System;

namespace Practice_12_1.Models
{
    public class LogInfoEventArgs : EventArgs
    {
        public DateTime Time { get; set; }
        public string AuthorName { get; set; }
        public string TransactionType { get; set; }
        public double TransactionSum { get; set; }
    }
}
