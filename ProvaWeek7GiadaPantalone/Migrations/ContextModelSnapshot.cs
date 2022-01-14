﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProvaWeek7GiadaPantalone;

#nullable disable

namespace ProvaWeek7GiadaPantalone.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProvaWeek7GiadaPantalone.Models.Cliente", b =>
                {
                    b.Property<string>("CodiceFiscale")
                        .HasMaxLength(16)
                        .HasColumnType("nchar(16)")
                        .IsFixedLength();

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CodiceFiscale");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("ProvaWeek7GiadaPantalone.Models.Polizza", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"), 1L, 1);

                    b.Property<string>("ClienteCodiceFiscale")
                        .IsRequired()
                        .HasColumnType("nchar(16)");

                    b.Property<DateTime>("DataStipula")
                        .HasColumnType("datetime2");

                    b.Property<float?>("ImportoAssicurato")
                        .HasColumnType("real");

                    b.Property<string>("PolizzaType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("RataMensile")
                        .HasColumnType("real");

                    b.HasKey("Numero");

                    b.HasIndex("ClienteCodiceFiscale");

                    b.ToTable("Polizza", (string)null);

                    b.HasDiscriminator<string>("PolizzaType").HasValue("polizza");
                });

            modelBuilder.Entity("ProvaWeek7GiadaPantalone.Models.PolizzaFurto", b =>
                {
                    b.HasBaseType("ProvaWeek7GiadaPantalone.Models.Polizza");

                    b.Property<int>("PercentualeCoperta")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("furto");
                });

            modelBuilder.Entity("ProvaWeek7GiadaPantalone.Models.PolizzaRCAuto", b =>
                {
                    b.HasBaseType("ProvaWeek7GiadaPantalone.Models.Polizza");

                    b.Property<int>("Cilindrata")
                        .HasColumnType("int");

                    b.Property<string>("Targa")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasDiscriminator().HasValue("RC Auto");
                });

            modelBuilder.Entity("ProvaWeek7GiadaPantalone.Models.PolizzaVita", b =>
                {
                    b.HasBaseType("ProvaWeek7GiadaPantalone.Models.Polizza");

                    b.Property<int>("AnniAssicurato")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("vita");
                });

            modelBuilder.Entity("ProvaWeek7GiadaPantalone.Models.Polizza", b =>
                {
                    b.HasOne("ProvaWeek7GiadaPantalone.Models.Cliente", "Cliente")
                        .WithMany("Polizze")
                        .HasForeignKey("ClienteCodiceFiscale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ProvaWeek7GiadaPantalone.Models.Cliente", b =>
                {
                    b.Navigation("Polizze");
                });
#pragma warning restore 612, 618
        }
    }
}