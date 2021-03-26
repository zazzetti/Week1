using System;
using System.Collections.Generic;
using System.Text;

namespace Week1.Handlers
{
    class Manager: AbstractHandler
    {

        public override bool Handle(Spesa spesa)
        {
            if (spesa.Importo >= 0 && spesa.Importo <= 400)
            {

                spesa.Approvata = true;
                spesa.LivelloApprovazione = "Manager";
                return true;
            }

            else return base.Handle(spesa);
        }
    }

  
   
}
