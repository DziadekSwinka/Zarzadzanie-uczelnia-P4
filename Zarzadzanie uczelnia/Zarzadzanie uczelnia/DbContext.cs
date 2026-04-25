using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Zarzadzanie_uczelnia.Models;


namespace Zarzadzanie_uczelnia
{
    internal class UczelniaContext: DbContext
    {    
        public DbSet<Student>Studenci { get; set; }
        public DbSet<Kierunek>Kierunki { get; set; }
        public DbSet<Grupa>Grupy {  get; set; }
        public DbSet<Przedmioty> Przedmiot { get; set; }
        public DbSet<Oceny> Ocena { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oceny>()
                .HasOne(o => o.Grupa)
                .WithMany(g => g.Oceny)
                .HasForeignKey(o => o.GrupaID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Oceny>()
                .HasOne(o => o.Przedmiot)
                .WithMany(p => p.Oceny)
                .HasForeignKey(o => o.PrzedmiotID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
