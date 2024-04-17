using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practice_12_1.Models
{
    internal class MoneyMover<T> : IMoneyMover<T> 
        where T : BankAccount
    {
        private T _accountFrom;
        private T _accountTo;

        public void SetAccounts(T accountFrom, T accountTo)
        {
            _accountFrom = accountFrom;
            _accountTo = accountTo;
        }

        public void MoveMoney(double sum)
        {
            bool canRemove = _accountFrom.RemoveMoney(sum);
            if (canRemove)
            {
                _accountTo.AddMoney(sum);
                MessageBox.Show("Перевод выполнен");
            }
            else
            {
                MessageBox.Show("Недостаточно средств для перевода");
            }
        }
    }
}
