using System;

namespace Practice_12_1.Exceptions
{
    internal class InputDataExceptions : Exception
    {
        public InputDataExceptions(string message) : base(message) { }
    }

    internal class MoneyLimitException : Exception
    {
        public MoneyLimitException(string message) : base(message) { }
    }
}
