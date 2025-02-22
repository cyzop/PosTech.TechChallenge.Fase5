﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PosTech.PortFolio.Repository.Sql;

#nullable disable

namespace PosTech.PortFolio.Repository.Sql.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240709125014_TipoAtivo")]
    partial class TipoAtivo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PosTech.PortFolio.Entities.AtivoEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(5)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(12)");

                    b.HasKey("Id");

                    b.ToTable("Ativo", (string)null);
                });

            modelBuilder.Entity("PosTech.PortFolio.Entities.ClienteEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("PosTech.PortFolio.Entities.PortFolioEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("ClienteId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("PortFolio", (string)null);
                });

            modelBuilder.Entity("PosTech.PortFolio.Entities.TransacaoEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AtivoId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("PortFolioId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("PortFolioId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INT");

                    b.Property<int>("TipoTransacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AtivoId");

                    b.HasIndex("PortFolioId");

                    b.ToTable("Transacao", (string)null);
                });

            modelBuilder.Entity("PosTech.PortFolio.Entities.PortFolioEntity", b =>
                {
                    b.HasOne("PosTech.PortFolio.Entities.ClienteEntity", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PosTech.PortFolio.Entities.TransacaoEntity", b =>
                {
                    b.HasOne("PosTech.PortFolio.Entities.AtivoEntity", "Ativo")
                        .WithMany()
                        .HasForeignKey("AtivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PosTech.PortFolio.Entities.PortFolioEntity", "PortFolio")
                        .WithMany()
                        .HasForeignKey("PortFolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ativo");

                    b.Navigation("PortFolio");
                });
#pragma warning restore 612, 618
        }
    }
}
