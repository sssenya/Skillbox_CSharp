using System;

namespace Practice_12_1.Accounts
{
    public class MoneyMover<T> : IMoneyMover<T> 
        where T : BankAccount
    {
        private T _accountFrom;
        private T _accountTo;

        public void SetAccounts(T accountFrom, T accountTo)
        {
            _accountFrom = accountFrom;
            _accountTo = accountTo;
        }

        public bool MoveMoney(double sum)
        {
            bool canRemove = _accountFrom.RemoveMoney(sum);
            if (canRemove)
            {
                _accountTo = (T)(_accountTo + sum);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
