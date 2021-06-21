using System;

namespace Light.Controller
{
    public class GetAllCommand : ProtocolCommand
    {
        public GetAllCommand(params string[] parameters) : base(parameters) { }

        protected override string ProtocolCommandName => "GETALL";

        protected override void validateParams(string[] parameters) { }
    }
}