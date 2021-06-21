namespace Light.Controller.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var communicator = new SerialCommunicator();
            var userTalker = new ConsoleTalker();

            new LightController(communicator, userTalker)
                .Start(args);
        }
    }
}
