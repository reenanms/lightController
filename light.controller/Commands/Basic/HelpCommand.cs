using System.Text;

namespace Light.Controller
{
    public class HelpCommand : ICommand
    {
        public void Run(ICommunicator communicator, IUserTalker userTalker)
        {
            var info = new StringBuilder()
                .AppendLine("Lista de comandos possíveis:");
            var commands = CommandFactory.getListOfCommands();
            foreach (var command in commands)
                info.AppendLine($"  {command}");
            userTalker.Write(info.ToString());
        }
    }
}