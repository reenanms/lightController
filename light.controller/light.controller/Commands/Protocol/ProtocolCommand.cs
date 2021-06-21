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
            public const string Success = "S";
            public const string Error = "E";
        }
        private string[] parameters;

        public ProtocolCommand(params string[] parameters)
        {
            this.parameters = parameters;
        }

        protected abstract string ProtocolCommandName { get; }
        protected abstract void validateParams(string[] parameters);

        public string Run(ICommunicator communicator)
        {
            using (var scope = new Scope(communicator.Open, communicator.Close))
            {
                validateParams(parameters);
                doRequest(communicator);
                var response = waitAndGetResponse(communicator);
                var responseData = response.Split($"{RequestConfig.CommandSeparator}");
                validateResponse(responseData);
                return responseData[1];
            }
        }

        private void doRequest(ICommunicator communicator)
        {
            var concarParams = string.Join(RequestConfig.ParamsSeparator, parameters);
            //REQUEST DATA: COMMAND:PARAM1,PARAM2,PARAM3,...;
            var commandProtocol = $"{ProtocolCommandName}{RequestConfig.CommandSeparator}{concarParams}{RequestConfig.EndChar}";
            communicator.WriteData(commandProtocol);
        }

        private string waitAndGetResponse(ICommunicator communicator)
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

        private void validateResponse(string[] responseData)
        {
            //RESPONSE DATA: STATUS:MESSAGE;
            if (!responseData[0].Equals(ResponseStatus.Success, StringComparison.CurrentCultureIgnoreCase))
                throw new OperationCommandException(responseData[1]);
        }
    }
}