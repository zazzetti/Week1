using System;
using System.Collections.Generic;
using System.Text;

namespace Week1.Handlers
{

    class OperationalManager : AbstractHandler
    {

        public override bool Handle(Spesa spesa)
        {
            if (spesa.Importo >= 401 && spesa.Importo <= 1000)
            {
                spesa.Approvata = true;
                spesa.LivelloApprovazione="Operational Manager";
                return true;
            }
                
            else return base.Handle(spesa);
        }
    }
}
