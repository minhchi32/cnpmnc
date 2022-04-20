using System;
using System.Globalization;

namespace cnpmnc.shared.Exceptions
{
    public class ErrorException : Exception
    {
        public ErrorException() : base()
        {
        }

        public ErrorException(string message) : base(message)
        {
        }

        public ErrorException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}