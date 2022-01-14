using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone.Models
{
    public class Cliente
    {
        
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
       

        public ICollection<Polizza> Polizze { get; set; } = new List<Polizza>();

        public float SumPolizze()
        {
           float somma = (float)Polizze.Sum(s => s.RataMensile);
            return somma;
        }

        public override string ToString()
        {
            return $"Cliente: {CodiceFiscale} - {Nome} {Cognome} - {Indirizzo}";
        }


    }
}
