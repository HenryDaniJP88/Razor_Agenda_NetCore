﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Razor_Agenda.Datos;

#nullable disable

namespace Razor_Agenda.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class AppicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Razor_Agenda.Modelos.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Razor_Agenda.Modelos.Contacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Contacto");
                });

            modelBuilder.Entity("Razor_Agenda.Modelos.Contacto", b =>
                {
                    b.HasOne("Razor_Agenda.Modelos.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
