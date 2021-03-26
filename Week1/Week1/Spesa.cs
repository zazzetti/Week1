using System;
using System.Collections.Generic;
using System.Text;

namespace Week1
{
    public abstract class Spesa
    {
        public DateTime Data { get; set; }
        public string Categoria { get; set; }

        public string Descrizione { get; set; }

        public double Importo { get; set; }

        public bool Approvata { get; set; }

        public string LivelloApprovazione { get; set; }

       

        public Spesa(DateTime data, string categoria, string descrizione, double importo)
        {
            Data = data;
            Categoria = categoria;
            Descrizione = descrizione;
            Importo = importo;
        }

        public override string ToString()
        {
            return "Spesa di " + Importo.ToString()+ " euro" + " Categoria: " + Categoria + " Descrizione: "+ Descrizione+  " in data: " + Data.ToShortDateString();
        }

        public abstract double GetRimborso();
    }
}
