using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
