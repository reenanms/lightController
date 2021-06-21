namespace Light.Controller
{
    public interface ICommunicator
    {
        void Open();
        void WriteData(string data);
        string ReadData(char endChar);
        void Close();
    }
}