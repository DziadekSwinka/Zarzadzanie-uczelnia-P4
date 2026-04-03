using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Zarzadzanie_uczelnia.Models;
using Newtonsoft.Json;


namespace Zarzadzanie_uczelnia
{
    internal class UczelniaContext: DbContext
        {    
            private readonly String connectionString = @"Server=KUBA_LAPTOP\SQLEXPRESS;Database=UczelniaDB;Trusted_Connection=True;TrustServerCertificate=True;";

    
        public DbSet<Student>Studenci { get; set; }
        public DbSet<Kierunek>Kierunki { get; set; }
        public DbSet<Grupa>Grupy {  get; set; }
        public DbSet<Przedmioty> Przedmiot { get; set; }
        public DbSet<Oceny> Ocena { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(
           connectionString);
        }
}
