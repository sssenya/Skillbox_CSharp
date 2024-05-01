using System;

namespace Practice_12_1.Models
{
    internal class NonDepositAccount : BankAccount
    {
        public new string Name => "Недепозитный счет";
    }
}
