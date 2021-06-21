using System.Text;

namespace Light.Controller
{
    public class HelpCommand : ICommand
    {
        public string Run(ICommunicator communicator)
        {
            var info = new StringBuilder()
                .AppendLine("Lista de comandos possíveis:");
            var commands = CommandFactory.getListOfCommands();
            foreach (var command in commands)
                info.AppendLine($"  {command}");
            return info.ToString();
        }
    }
}