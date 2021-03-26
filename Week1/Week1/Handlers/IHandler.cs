using System;
using System.Collections.Generic;
using System.Text;

namespace Week1.Handlers
{
    interface IHandler
    {

        IHandler SetNext(IHandler handler);


        bool Handle(Spesa spesa);
    }
}