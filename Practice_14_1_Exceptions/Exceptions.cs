using System;

namespace Practice_14_1.Exceptions
{
    public class InputDataExceptions : Exception
    {
        public InputDataExceptions(string message) : base(message) { }
    }

    public class MoneyLimitException : Exception
    {
        public MoneyLimitException(string message) : base(message) { }
    }
}
