using ProvaWeek7GiadaPantalone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone.Repository
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        public Cliente? GetByCodiceFiscale (string codiceFiscale);

    }
}
