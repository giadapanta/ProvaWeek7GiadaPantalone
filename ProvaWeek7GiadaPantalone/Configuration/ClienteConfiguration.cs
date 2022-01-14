using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaWeek7GiadaPantalone.Models;

namespace ProvaWeek7GiadaPantalone
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.Property(c => c.CodiceFiscale).IsFixedLength().HasMaxLength(16);
            builder.HasKey(k => k.CodiceFiscale);
            builder.Property(c => c.Nome).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Cognome).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Indirizzo).HasMaxLength(50);

            builder.HasMany(p => p.Polizze).WithOne(c => c.Cliente).HasForeignKey(c => c.ClienteCodiceFiscale);


        }
    }
}