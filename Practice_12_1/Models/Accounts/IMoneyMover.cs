using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_1.Models
{
    internal interface IMoneyMover<in T>
        where T : BankAccount
    {
        void SetAccounts(T accountFrom, T accountTo);

        bool MoveMoney(double sum);
    }
}
