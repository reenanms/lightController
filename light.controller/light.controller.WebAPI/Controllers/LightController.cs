using Light.Controller;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Light.Controller.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LightController : ControllerBase
    {
        public record LightState(int Port, bool isOn);

        private ICommunicator communicator;
        public LightController()
            => communicator = new SerialCommunicator();

        [HttpGet]
        public IEnumerable<LightState> Get()
        {
            var command = new GetAllCommand();
            var result = command.Run(communicator);
            var portsAndStates = result.Split(ProtocolCommand.RequestConfig.ParamsSeparator);
            foreach (var portAndState in portsAndStates)
            {
                var val = portAndState.Split("=");
                yield return new LightState(int.Parse(val[0]), val[1] == "1");
            }
        }

        [HttpGet, Route("{port}")]
        public LightState Get(int port)
        {
            var command = new GetCommand($"{port}");
            var state = command.Run(communicator);
            return new LightState(port, state == "1");
        }

        [HttpPost, Route("{port}/on")]
        public void TurnOn(int port)
        {
            var command = new TurnOnCommand($"{port}");
            command.Run(communicator);
        }

        [HttpPost, Route("{port}/off")]
        public void TurnOff(int port)
        {
            var command = new TurnOffCommand($"{port}");
            command.Run(communicator);
        }
    }
}
