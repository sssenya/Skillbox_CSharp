using Practice_12_1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_1.Models
{
    internal class AccountCalculator<T>
        where T : IBankAccount
    {
        public static bool MoveMoney(T accountFrom, T accountTo, double sum)
        {
            bool result = RemoveMoney(accountFrom, sum);
            if (result)
            {
                AddMoney(accountTo, sum);
                return true;
            }
            return false;
        }

        public static bool AddMoney(T account, double sum)
        {
            account.Balance += sum;
            return true;
        }

        public static bool RemoveMoney(T account, double sum)
        {
            if (account.Balance >= sum)
            {
                account.Balance -= sum;
                return true;
            }
            return false;
        }
    }
}
