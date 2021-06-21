using System;

namespace Light.Controller
{
    public class OperationCommandException : Exception
    {
        public OperationCommandException(string message) : base(message) { }
    }
}