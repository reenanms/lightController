using System;

namespace Light.Controller
{
    public class TurnOffCommand : ProtocolCommand
    {
        public TurnOffCommand(params string[] parameters) : base(parameters) { }

        protected override string ProtocolCommandName => "OFF";

        protected override void validateParams(string[] parameters)
        {
            if (parameters.Length != 1)
                throw new InvalidCommandParamException();
        }
    }
}