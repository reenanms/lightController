using System;

namespace Light.Controller
{
    public class LightController
    {
        private ICommunicator communicator;
        private IUserTalker userTalker;

        public LightController(ICommunicator communicator, IUserTalker userTalker)
        {
            this.communicator = communicator;
            this.userTalker = userTalker;
        }

        public void Start(string[] args)
        {
            tryRunCommand(args);
        }

        private void tryRunCommand(string[] args)
        {
            try
            {
                var command = CommandFactory.Create(args);
                var result = command.Run(communicator);
                userTalker.Write(result);
            }
            catch (Exception e)
            {
                userTalker.Write(e.Message);
            }
        }
    }
}