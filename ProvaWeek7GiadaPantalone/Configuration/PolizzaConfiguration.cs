using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaWeek7GiadaPantalone.Models;

namespace ProvaWeek7GiadaPantalone
{
    internal class PolizzaConfiguration : IEntityTypeConfiguration<Polizza>
    {
        public void Configure(EntityTypeBuilder<Polizza> builder)
        {
            builder.ToTable("Polizza");
            builder.HasKey(p => p.Numero);

            builder.HasOne(c => c.Cliente).WithMany(p => p.Polizze).HasForeignKey(p=>p.ClienteCodiceFiscale);


            builder.HasDiscriminator<string>("PolizzaType")
                .HasValue<Polizza>("polizza")
                .HasValue<PolizzaRCAuto>("RC Auto")
                .HasValue<PolizzaFurto>("furto")
                .HasValue<PolizzaVita>("vita");
                       
        }
    }
}