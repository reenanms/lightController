namespace Light.Controller
{
    public interface ICommand
    {
        string Run(ICommunicator communicator);
    }
}