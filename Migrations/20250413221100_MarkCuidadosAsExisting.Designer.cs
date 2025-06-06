﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooAPI.Data;

#nullable disable

namespace ZooAPI.Migrations
{
    [DbContext(typeof(ZooContext))]
    [Migration("20250413221100_MarkCuidadosAsExisting")]
    partial class MarkCuidadosAsExisting
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZooAPI.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Habitat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisOrigem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("ZooAPI.Models.AnimalCuidado", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("CuidadoId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId", "CuidadoId");

                    b.HasIndex("CuidadoId");

                    b.ToTable("AnimalCuidados");
                });

            modelBuilder.Entity("ZooAPI.Models.Cuidado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cuidados");
                });

            modelBuilder.Entity("ZooAPI.Models.AnimalCuidado", b =>
                {
                    b.HasOne("ZooAPI.Models.Animal", "Animal")
                        .WithMany("AnimalCuidados")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooAPI.Models.Cuidado", "Cuidado")
                        .WithMany("AnimalCuidados")
                        .HasForeignKey("CuidadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Cuidado");
                });

            modelBuilder.Entity("ZooAPI.Models.Animal", b =>
                {
                    b.Navigation("AnimalCuidados");
                });

            modelBuilder.Entity("ZooAPI.Models.Cuidado", b =>
                {
                    b.Navigation("AnimalCuidados");
                });
#pragma warning restore 612, 618
        }
    }
}
