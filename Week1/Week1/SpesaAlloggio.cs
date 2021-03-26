using System;
using System.Collections.Generic;
using System.Text;

namespace Week1
{
    class SpesaAlloggio:Spesa
    {
        public SpesaAlloggio(DateTime data, string categoria, string descrizione, double importo) : base(data, categoria, descrizione, importo)
        {
        }

        public override double GetRimborso()
        {
            if (Approvata == true)
                return Importo;
            else return 0;
        }
    }
}
