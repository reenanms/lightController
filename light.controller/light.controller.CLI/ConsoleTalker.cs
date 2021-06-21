using System;

namespace Light.Controller.CLI
{
    public class ConsoleTalker : IUserTalker
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Write(string data)
        {
            Console.WriteLine(data);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}