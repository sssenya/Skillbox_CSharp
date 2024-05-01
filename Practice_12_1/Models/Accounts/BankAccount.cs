using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_1.Models
{
    internal class BankAccount : IBankAccount
    {
        public BankAccount()
        {
            OpeningDate = DateTime.Now;
        }

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

        public static BankAccount operator +(BankAccount account, double money)
        {
            account.AddMoney(money);
            return account;
        }
    }
}
