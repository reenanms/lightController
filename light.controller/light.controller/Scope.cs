using System;

namespace Light.Controller
{
    public class Scope : IDisposable
    {
        private Action disposeAction;

        public Scope(Action startAction, Action disposeAction)
        {
            startAction();
            this.disposeAction = disposeAction;
        }

        public void Dispose()
        {
            disposeAction();
        }
    }
}