using Microsoft.EntityFrameworkCore;
using ProvaWeek7GiadaPantalone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone.Repository
{
    internal class RepositoryPolizza : IRepositoryPolizza
    {
        public Polizza Create(Polizza item)
        {
            using (var ctx = new Context())
            {
                ctx.Polizze.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public ICollection<Polizza> GetAll()
        {
          using(var ctx = new Context())
            {
                return ctx.Polizze.Include(c => c.Cliente).ToList();
            }
        }

        public Polizza GetByNumero(int numero)
        {
           return GetAll().FirstOrDefault(p =>p.Numero == numero);
        }
    }
}
