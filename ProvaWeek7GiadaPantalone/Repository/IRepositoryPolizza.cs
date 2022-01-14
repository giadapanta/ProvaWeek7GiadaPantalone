using ProvaWeek7GiadaPantalone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone.Repository
{
    internal interface IRepositoryPolizza: IRepository<Polizza>
    {
        public Polizza GetByNumero(int numero);

    }
}
