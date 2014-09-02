using System;

namespace TDDKata2
{
    public class NegativesNumberException : Exception
    {
        public NegativesNumberException() {}

        public NegativesNumberException(string message)
            : base(message) {}
    }
}