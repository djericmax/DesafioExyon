using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ApiExyon.Models;

namespace ApiExyon.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CiaAerea> CiaAereas { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Voo> Voos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=bcoPassagensAereas.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CiaAerea>().HasData(new List<CiaAerea>() {
                new CiaAerea(1, "Gol", "3", "120"),
                new CiaAerea(2, "LaTam", "2", "120"),
                new CiaAerea(3, "Vasp", "4", "120"),
                new CiaAerea(4, "Varig", "1", "120")
            });

            builder.Entity<Passageiro>().HasData(new List<Passageiro>() {
                new Passageiro(1, "12345678978", "Roberto Carlos", "de Lima"),
                new Passageiro(2, "45454545445", "Dercy", "Gonçalves"),
                new Passageiro(3, "14141414141", "Marcos", "Palmeiras"),
                new Passageiro(4, "97878979845", "Humberto", "Martins"),
                new Passageiro(5, "54343535454", "Khloé", "Kardashian"),
            });

            builder.Entity<Voo>().HasData(new List<Voo>() {
                new Voo(1, "1", "B01", "07-12-2020", "18:05", "325.25", "2", "5"),
                new Voo(2, "1", "B14", "07-12-2020", "18:05", "230.25", "2", "3"),
                new Voo(3, "2", "A09", "08-12-2020", "13:55", "480.75", "4", "2"),
                new Voo(4, "2", "A14", "08-12-2020", "13:55", "487.25", "4", "4"),
                new Voo(5, "2", "C21", "08-12-2020", "13:55", "300.75", "4", "1"),
            });
        }
    }
}
