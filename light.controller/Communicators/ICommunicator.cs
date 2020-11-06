using System;

namespace Light.Controller
{
    public interface ICommunicator
    {
        void Open();
        void WriteData(String data);
        String ReadData(char endChar);
        void Close();
    }
}