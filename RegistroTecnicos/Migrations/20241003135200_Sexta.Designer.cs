﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicos.DAL;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241003135200_Sexta")]
    partial class Sexta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("RegistroTecnicos.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WhatsApp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Prioridades", b =>
                {
                    b.Property<int>("PrioridadesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tiempo")
                        .HasColumnType("INTEGER");

                    b.HasKey("PrioridadesId");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SueldoHora")
                        .HasColumnType("REAL");

                    b.Property<int>("TiposTecnicosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TecnicoId");

                    b.HasIndex("TiposTecnicosId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TiposTecnicos", b =>
                {
                    b.Property<int>("TiposTecnicosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TiposTecnicosId");

                    b.ToTable("TiposTecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Property<int>("TrabajoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("PrioridadId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TrabajoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("Trabajos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.TiposTecnicos", "TipoTecnico")
                        .WithMany()
                        .HasForeignKey("TiposTecnicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoTecnico");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.HasOne("RegistroTecnicos.Models.Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Prioridades", "Prioridad")
                        .WithMany()
                        .HasForeignKey("PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegistroTecnicos.Models.Tecnicos", "Tecnico")
                        .WithMany()
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Prioridad");

                    b.Navigation("Tecnico");
                });
#pragma warning restore 612, 618
        }
    }
}