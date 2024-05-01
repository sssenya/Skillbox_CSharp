using System;

namespace Practice_12_1.Accounts
{
    public interface IMoneyMover<in T>
        where T : BankAccount
    {
        void SetAccounts(T accountFrom, T accountTo);

        bool MoveMoney(double sum);
    }
}
