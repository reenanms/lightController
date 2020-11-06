using System;

namespace Light.Controller
{
    public interface IUserTalker
    {
        void Clear();
        void Write(String data);
        String Read();
    }
}