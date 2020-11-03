// Use this code inside a project created with the Visual C# > Windows Desktop > Console Application template.
// Replace the code in Program.cs with this code.

using System;
using System.IO.Ports;
using System.Threading;

public class Program
{
    public static void Main()
    {
        var serialPort = new SerialPort();
        serialPort.PortName = "COM1";
        serialPort.BaudRate = 9600;
        serialPort.Parity = Parity.None;;
        serialPort.DataBits = 8;
        serialPort.StopBits = StopBits.One;
        serialPort.Handshake = Handshake.None;

        // Set the read/write timeouts
        serialPort.ReadTimeout = 500;
        serialPort.WriteTimeout = 500;

        serialPort.Open();
        
        bool isAlive = true;
        var readThread = new Thread(() => {
            while (isAlive)
            {
                try
                {
                    var message = serialPort.ReadLine();
                    Console.WriteLine($"Data received : {message}");
                }
                catch (TimeoutException) { }
            }
        });
        readThread.Start();



        Console.WriteLine("Q to QUIT or other message to send");
        while (isAlive)
        {
            var message = Console.ReadLine();
            if (message.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                isAlive = false;
            }
            else
            {
                serialPort.WriteLine(message);
            }
        }

        readThread.Join();
        serialPort.Close();
    }
}