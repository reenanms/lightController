using System;

namespace Light.Controller
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException() : base("Comando inválido") { }
    }
}