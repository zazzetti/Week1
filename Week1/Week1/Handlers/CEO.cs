using System;
using System.Collections.Generic;
using System.Text;

namespace Week1.Handlers
{
    class CEO : AbstractHandler
    {

        public override bool Handle(Spesa spesa)
        {
            if (spesa.Importo >= 1001 && spesa.Importo < 2500)
            {
                spesa.Approvata = true;
                spesa.LivelloApprovazione = "CEO";
                return true;
            }
  
            else return base.Handle(spesa);
        }
    }
}
