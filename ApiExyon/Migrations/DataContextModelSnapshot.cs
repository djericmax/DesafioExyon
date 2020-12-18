﻿// <auto-generated />
using System;
using ApiExyon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiExyon.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("ApiExyon.Models.CiaAerea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Aviao")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanhiaAerea")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("QtdeAssentos")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CiaAereas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aviao = "3",
                            CompanhiaAerea = "Gol",
                            QtdeAssentos = "120"
                        },
                        new
                        {
                            Id = 2,
                            Aviao = "2",
                            CompanhiaAerea = "LaTam",
                            QtdeAssentos = "120"
                        },
                        new
                        {
                            Id = 3,
                            Aviao = "4",
                            CompanhiaAerea = "Vasp",
                            QtdeAssentos = "120"
                        },
                        new
                        {
                            Id = 4,
                            Aviao = "1",
                            CompanhiaAerea = "Varig",
                            QtdeAssentos = "120"
                        });
                });

            modelBuilder.Entity("ApiExyon.Models.Passageiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(11);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Passageiros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "12345678978",
                            Nome = "Roberto Carlos",
                            Sobrenome = "de Lima"
                        },
                        new
                        {
                            Id = 2,
                            CPF = "45454545445",
                            Nome = "Dercy",
                            Sobrenome = "Gonçalves"
                        },
                        new
                        {
                            Id = 3,
                            CPF = "14141414141",
                            Nome = "Marcos",
                            Sobrenome = "Palmeiras"
                        },
                        new
                        {
                            Id = 4,
                            CPF = "97878979845",
                            Nome = "Humberto",
                            Sobrenome = "Martins"
                        },
                        new
                        {
                            Id = 5,
                            CPF = "54343535454",
                            Nome = "Khloé",
                            Sobrenome = "Kardashian"
                        });
                });

            modelBuilder.Entity("ApiExyon.Models.Voo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Assento")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(8);

                    b.Property<int>("CiaAereaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataPartida")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Horapartida")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumdoVoo")
                        .HasColumnType("TEXT");

                    b.Property<int>("PassageiroId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorPassagem")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CiaAereaId");

                    b.HasIndex("PassageiroId");

                    b.ToTable("Voos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assento = "B01",
                            CiaAereaId = 2,
                            DataPartida = new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Horapartida = new DateTime(2020, 12, 12, 18, 5, 0, 0, DateTimeKind.Unspecified),
                            NumdoVoo = "1",
                            PassageiroId = 5,
                            ValorPassagem = "325.25"
                        },
                        new
                        {
                            Id = 2,
                            Assento = "B14",
                            CiaAereaId = 2,
                            DataPartida = new DateTime(2020, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Horapartida = new DateTime(2020, 12, 12, 18, 5, 0, 0, DateTimeKind.Unspecified),
                            NumdoVoo = "1",
                            PassageiroId = 3,
                            ValorPassagem = "230.25"
                        },
                        new
                        {
                            Id = 3,
                            Assento = "A09",
                            CiaAereaId = 4,
                            DataPartida = new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Horapartida = new DateTime(2020, 12, 12, 13, 55, 0, 0, DateTimeKind.Unspecified),
                            NumdoVoo = "2",
                            PassageiroId = 2,
                            ValorPassagem = "480.75"
                        },
                        new
                        {
                            Id = 4,
                            Assento = "A14",
                            CiaAereaId = 4,
                            DataPartida = new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Horapartida = new DateTime(2020, 12, 12, 13, 55, 0, 0, DateTimeKind.Unspecified),
                            NumdoVoo = "2",
                            PassageiroId = 4,
                            ValorPassagem = "487.25"
                        },
                        new
                        {
                            Id = 5,
                            Assento = "C21",
                            CiaAereaId = 4,
                            DataPartida = new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Horapartida = new DateTime(2020, 12, 12, 13, 55, 0, 0, DateTimeKind.Unspecified),
                            NumdoVoo = "2",
                            PassageiroId = 1,
                            ValorPassagem = "300.75"
                        });
                });

            modelBuilder.Entity("ApiExyon.Models.Voo", b =>
                {
                    b.HasOne("ApiExyon.Models.CiaAerea", "CiaAerea")
                        .WithMany()
                        .HasForeignKey("CiaAereaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiExyon.Models.Passageiro", "Passageiro")
                        .WithMany()
                        .HasForeignKey("PassageiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
