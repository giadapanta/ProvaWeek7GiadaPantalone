using ProvaWeek7GiadaPantalone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone.Repository
{
    internal class RepositoryCliente : IRepositoryCliente
    {
        public Cliente Create(Cliente item)
        {
            using(var ctx = new Context())
            {
                ctx.Clienti.Add(item);
                ctx.SaveChanges();
            }
            return item;    
        }

        public ICollection<Cliente> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Clienti.ToList();
            }
        }

        public Cliente? GetByCodiceFiscale(string codiceFiscale)
        {
            return GetAll().FirstOrDefault(c => c.CodiceFiscale == codiceFiscale);
        }
    }
}
