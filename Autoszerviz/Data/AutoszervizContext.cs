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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ugyfel>().HasData(
                new Ugyfel { Id = 1, Nev = "Nagy Péter", Telefon = "+36 30 123 4567", Email = "nagy.peter@gmail.com" },
                new Ugyfel { Id = 2, Nev = "Szabó Anna", Telefon = "+36 20 987 6543", Email = "szabo.anna@freemail.hu" },
                new Ugyfel { Id = 3, Nev = "Tóth Gábor", Telefon = "+36 70 555 1212", Email = null }
            );
        }
    }
}
