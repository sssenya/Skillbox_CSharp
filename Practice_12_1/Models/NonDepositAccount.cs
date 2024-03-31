using Practice_12_1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_1.Models
{
    internal class NonDepositAccount : IBankAccount
    {
        public double Balance { get; set; }
        public double Percent { get; set; }
        public DateTime OpeningDate { get; set; }
    }
}
