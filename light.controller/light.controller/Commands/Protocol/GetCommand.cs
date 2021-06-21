using System;

namespace Light.Controller
{
    public class GetCommand : ProtocolCommand
    {
        public GetCommand(params string[] parameters) : base(parameters) { }

        protected override string ProtocolCommandName => "GET";

        protected override void validateParams(string[] parameters)
        {
            if (parameters.Length != 1)
                throw new InvalidCommandParamException();
        }
    }
}