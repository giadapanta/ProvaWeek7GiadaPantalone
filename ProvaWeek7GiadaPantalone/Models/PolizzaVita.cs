using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone.Models
{
    internal class PolizzaVita: Polizza
    {
        public int AnniAssicurato { get; set; }

        public override string ToString()
        {
            return "\nPolizza Vita" + base.ToString() + $" Anni: {AnniAssicurato}";
        }
    }
}
