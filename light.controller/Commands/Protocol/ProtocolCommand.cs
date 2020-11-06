using System;

namespace Light.Controller
{
    public abstract class ProtocolCommand : ICommand
    {
        public class RequestConfig
        {
            public const char CommandSeparator = ':';
            public const char ParamsSeparator = ',';
            public const char EndChar = ';';
        }

        public class ResponseStatus
        {
            public const String Success = "S";
            public const String Error = "E";
        }
        private String[] parameters;

        public ProtocolCommand(params String[] parameters)
        {
            this.parameters = parameters;
        }

        protected abstract String ProtocolCommandName { get; }
        protected abstract void validateParams(string[] parameters);

        public void Run(ICommunicator communicator, IUserTalker userTalker)
        {
            using (var scope = new Scope(communicator.Open, communicator.Close))
            {
                validateParams(parameters);
                doRequest(communicator);
                var response = waitAndGetResponse(communicator);
                varlidateResponse(response);
            }
        }

        private void doRequest(ICommunicator communicator)
        {
            var concarParams = String.Join(RequestConfig.ParamsSeparator, parameters);
            //REQUEST DATA: COMMAND:PARAM1,PARAM2,PARAM3,...;
            var commandProtocol = $"{ProtocolCommandName}{RequestConfig.CommandSeparator}{concarParams}{RequestConfig.EndChar}";
            communicator.WriteData(commandProtocol);
        }

        private String waitAndGetResponse(ICommunicator communicator)
        {
            while (true)
            {
                try
                {
                    return communicator.ReadData(RequestConfig.EndChar);
                }
                catch (TimeoutException)
                {
                }
            }
        }

        private void varlidateResponse(String response)
        {
            var responseData = response.Split($"{RequestConfig.CommandSeparator}");
            //RESPONSE DATA: STATUS:MESSAGE;
            if (!responseData[0].Equals(ResponseStatus.Success, StringComparison.CurrentCultureIgnoreCase))
                throw new OperationCommandException(responseData[1]);
        }
    }
}