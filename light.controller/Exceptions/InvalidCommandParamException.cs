using System;

namespace Light.Controller
{
    public class InvalidCommandParamException : Exception
    {
        public InvalidCommandParamException() : base("Paramêtro(s) inválidos") { }
    }
}