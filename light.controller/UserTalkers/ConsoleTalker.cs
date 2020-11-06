using System;

namespace Light.Controller
{
    public class ConsoleTalker : IUserTalker
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Write(String data)
        {
            Console.WriteLine(data);
        }

        public String Read()
        {
            return Console.ReadLine();
        }
    }
}