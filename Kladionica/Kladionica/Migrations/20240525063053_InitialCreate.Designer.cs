﻿// <auto-generated />
using System;
using Kladionica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kladionica.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240525063053_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kladionica.Models.Korisnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Datum_rođenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Korisniks");
                });

            modelBuilder.Entity("Kladionica.Models.Oklada", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_korisnik")
                        .HasColumnType("int");

                    b.Property<string>("TipOklade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ulog")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ID_korisnik");

                    b.ToTable("Okladas");
                });

            modelBuilder.Entity("Kladionica.Models.Utakmica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_oklada")
                        .HasColumnType("int");

                    b.Property<string>("Tim1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tim2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ID_oklada");

                    b.ToTable("Utakmicas");
                });

            modelBuilder.Entity("Kladionica.Models.Oklada", b =>
                {
                    b.HasOne("Kladionica.Models.Korisnik", "Korisnik")
                        .WithMany("Oklade")
                        .HasForeignKey("ID_korisnik")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("Kladionica.Models.Utakmica", b =>
                {
                    b.HasOne("Kladionica.Models.Oklada", "Oklada")
                        .WithMany("Utakmice")
                        .HasForeignKey("ID_oklada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oklada");
                });

            modelBuilder.Entity("Kladionica.Models.Korisnik", b =>
                {
                    b.Navigation("Oklade");
                });

            modelBuilder.Entity("Kladionica.Models.Oklada", b =>
                {
                    b.Navigation("Utakmice");
                });
#pragma warning restore 612, 618
        }
    }
}
