using System;

namespace Light.Controller
{
    public interface IUserTalker
    {
        void Clear();
        void Write(string data);
        string Read();
    }
}