using System;
using System.Collections.Generic;
using System.Text;

namespace Week1
{
    class Factory
    {

        public static Spesa FactorySpesaPerCategoria(DateTime data, string categoria, string descrizione, double importo)
        {
            Spesa spesa = null;
            if (categoria.Equals("Alloggio"))
            {
                spesa = new SpesaAlloggio(data, categoria, descrizione, importo);


            }
            else if (categoria.Equals("Viaggio"))
            {
                spesa = new SpesaAlloggio(data, categoria, descrizione, importo);
            }
            else if (categoria.Equals("Vitto"))
            {
                spesa = new SpesaVitto(data, categoria, descrizione, importo);
            }
            else
            {
                spesa = new SpesaAltro(data, categoria, descrizione, importo);
            }

            return spesa;

        }
    }
}
