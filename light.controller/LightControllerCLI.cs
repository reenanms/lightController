using System;
using System.Text;

namespace Light.Controller
{
    public class LightControllerCLI
    {
        private ICommunicator communicator;
        private IUserTalker userTalker;

        public LightControllerCLI(ICommunicator communicator, IUserTalker userTalker)
        {
            this.communicator = communicator;
            this.userTalker = userTalker;
        }

        public void Start()
        {
            var stringBuilder = new StringBuilder()
                .AppendLine("Digite o comando a ser executado")
                .AppendLine("*Q para SAIR ou HELP para ajuda");
            userTalker.Write(stringBuilder.ToString());
            
            while (true)
            {
                var rawCommand = userTalker.Read();
                if (isCloseCommand(rawCommand))
                    break;
                
                tryRunCommand(rawCommand);
            }
        }

        private void tryRunCommand(String rawCommand)
        {
            try
            {
                var command = CommandFactory.Create(rawCommand);
                command.Run(communicator, userTalker);
                userTalker.Write("Comando executado com sucesso!");
            }
            catch (Exception e)
            {
                userTalker.Write(e.Message);
            }
        }
        
        private static bool isCloseCommand(String rawCommand)
        {
            return rawCommand.Equals("q", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}