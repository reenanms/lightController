using System;

namespace Light.Controller
{
    public class TurnOnCommand : ProtocolCommand
    {
        public TurnOnCommand(params string[] parameters) : base(parameters) { }

        protected override string ProtocolCommandName => "ON";

        protected override void validateParams(string[] parameters)
        {
            if (parameters.Length != 1)
                throw new InvalidCommandParamException();
        }
    }
}