using System;

namespace Light.Controller
{
    public class OperationCommandException : Exception
    {
        public OperationCommandException(String message) : base(message) { }
    }
}