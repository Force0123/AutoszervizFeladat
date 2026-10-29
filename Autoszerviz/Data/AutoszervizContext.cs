using Autoszerviz.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoszerviz.Data
{
    public class AutoszervizContext : DbContext
    {
        public AutoszervizContext(DbContextOptions<AutoszervizContext> options) : base(options)
        {
        }

        public DbSet<Ugyfel> Ugyfelek { get; set; }
        public DbSet<Javitas> Javitasok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Javitas>()
                .HasOne(j => j.Ugyfel)
                .WithMany(u => u.Javitasok)
                .HasForeignKey(j => j.UgyfelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ugyfel>().HasData(
                new Ugyfel { Id = 1, Nev = "Nagy Péter", Telefon = "+36 30 123 4567", Email = "nagy.peter@gmail.com" },
                new Ugyfel { Id = 2, Nev = "Szabó Anna", Telefon = "+36 20 987 6543", Email = "szabo.anna@freemail.hu" },
                new Ugyfel { Id = 3, Nev = "Tóth Gábor", Telefon = "+36 70 555 1212", Email = null }
            );

            modelBuilder.Entity<Javitas>().HasData(
                new Javitas { Id = 1, UgyfelId = 1, Rendszam = "MKR-421", Leiras = "Fékbetét csere elöl", Koltseg = 38000, Allapot = "Kész", FelvetelDatuma = new DateTime(2026, 10, 5) },
                new Javitas { Id = 2, UgyfelId = 1, Rendszam = "MKR-421", Leiras = "Olajcsere és szűrők", Koltseg = 29500, Allapot = "Folyamatban", FelvetelDatuma = new DateTime(2026, 10, 20) },
                new Javitas { Id = 3, UgyfelId = 2, Rendszam = "PLT-708", Leiras = "Klíma töltés", Koltseg = null, Allapot = "Felvéve", FelvetelDatuma = new DateTime(2026, 10, 24) }
            );
        }
    }
}
