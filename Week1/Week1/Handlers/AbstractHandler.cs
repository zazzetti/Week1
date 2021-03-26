using System;
using System.Collections.Generic;
using System.Text;

namespace Week1.Handlers
{

    abstract class AbstractHandler : IHandler
    {
        private IHandler NextHandler;
        public virtual bool Handle(Spesa spesa)
        {
            if (this.NextHandler != null)
                return this.NextHandler.Handle(spesa);
            else return false;
        }

        public IHandler SetNext(IHandler handler)
        {
            NextHandler = handler;
            return NextHandler;
        }
    }

}
