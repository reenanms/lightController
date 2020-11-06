namespace Light.Controller
{
    public interface ICommand
    {
        void Run(ICommunicator communicator, IUserTalker userTalker);
    }
}