using System;
using System.IO.Ports;

namespace Light.Controller
{
    public class SerialCommunicator : ICommunicator
    {
        private SerialPort serialPort;

        public SerialCommunicator()
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM1";
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None; ;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;
        }

        public void Open()
        {
            serialPort.Open();
        }

        public void WriteData(string data)
        {
            serialPort.Write(data);
        }

        public string ReadData(char endChar)
        {
            return serialPort.ReadTo($"{endChar}");
        }

        public void Close()
        {
            serialPort.Close();
        }
    }
}