using Microsoft.EntityFrameworkCore;
using ProvaWeek7GiadaPantalone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaWeek7GiadaPantalone
{
    internal class Context : DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Polizza> Polizze { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AssicurazioneDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
           modelBuilder.ApplyConfiguration<Polizza>(new PolizzaConfiguration());
        }
    }
}
