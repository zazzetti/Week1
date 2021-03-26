using System;
using System.Collections.Generic;
using System.Text;

namespace Week1
{
    class SpesaVitto: Spesa
    {

        public SpesaVitto(DateTime data, string categoria, string descrizione, double importo) : base(data, categoria, descrizione, importo)
        {
        }

        public override double GetRimborso()
        {
            if (Approvata == true)
                return Importo * 0.7;
            else return 0;
        }
    }
}
