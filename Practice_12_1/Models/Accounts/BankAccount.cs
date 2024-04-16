using Practice_12_1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_1.Models.Accounts
{
    internal class BankAccount : IBankAccount
    {
        public string Name { get; }
        public double Balance { get; set; }
        public double Percent { get; set; }
        public DateTime OpeningDate { get; set; }

        public void AddMoney(double sum) 
        {
            Balance += sum;
        }

        public bool RemoveMoney(double sum) 
        {
            if (Balance >= sum)
            {
                Balance -= sum;
                return true;
            }
            return false;
        }
    }
}
