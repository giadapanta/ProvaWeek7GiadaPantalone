using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone.Models
{
    internal class PolizzaRCAuto: Polizza
    {
        [MinLength(5), MaxLength(5)]
        public string Targa { get; set; }
        public int Cilindrata { get; set; }

        public override string ToString()
        {
            return "\nPolizza RC Auto" +base.ToString() + $" targa: {Targa} - {Cilindrata} cc";
        }
    }
}
