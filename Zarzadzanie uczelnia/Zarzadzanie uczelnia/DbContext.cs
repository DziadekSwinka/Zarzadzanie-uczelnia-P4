using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Zarzadzanie_uczelnia.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;


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
    }
}
