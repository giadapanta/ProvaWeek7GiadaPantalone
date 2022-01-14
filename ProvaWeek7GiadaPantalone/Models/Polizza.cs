using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone.Models
{
    public class Polizza
    {
        public int Numero { get; set; }
        public DateTime DataStipula { get; set; }
        public float? ImportoAssicurato { get; set; }
        public float? RataMensile { get; set; }

        public string ClienteCodiceFiscale { get; set; }
        public Cliente Cliente { get; set; }

        public override string ToString()
        {
            return $"\nPolizza numero: {Numero}, data stipulazione: {DataStipula.ToShortDateString()}" +
                $" importo ass. : {ImportoAssicurato} Euro, rata mensile {RataMensile} Euro";
          
        }

    }
}
