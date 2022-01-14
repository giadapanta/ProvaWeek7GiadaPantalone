using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone.Models
{
    internal class PolizzaFurto: Polizza
    {
        public int PercentualeCoperta { get; set; }

        public override string ToString()
        {
            return "\nPolizza Furto" + base.ToString() + $" copertura del {PercentualeCoperta}%";
        }
    }
}
