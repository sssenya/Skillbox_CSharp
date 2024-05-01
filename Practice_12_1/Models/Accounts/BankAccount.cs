using Practice_12_1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
            {
                if (Balance < sum)
                {
                    throw new MoneyLimitException("Недостаточно средств на счете");
                }
                Balance -= sum;
                return true;
            }
            catch(MoneyLimitException exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static BankAccount operator +(BankAccount account, double money)
        {
            account.AddMoney(money);
            return account;
        }
    }
}
