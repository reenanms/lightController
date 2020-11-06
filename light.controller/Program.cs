using System;
using System.IO.Ports;
using System.Threading;

namespace Light.Controller
{
    public class Program
    {
        public static void Main()
        {
            var communicator = new SerialCommunicator();
            var userTalker = new ConsoleTalker();
            
            new LightController(communicator, userTalker)
                .Start();
        }
    }
}