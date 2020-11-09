namespace Light.Controller
{
    public class Program
    {
        public static void Main()
        {
            var communicator = new SerialCommunicator();
            var userTalker = new ConsoleTalker();
            
            new LightControllerCLI(communicator, userTalker)
                .Start();
        }
    }
}