using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Zarzadzanie_uczelnia
{
    internal class UczelniaContext: DbContext
    {
        public DbSet<Student>Studenci { get; set; }
        public DbSet<Kierunek>Kierunki { get; set; }
        public DbSet<Grupa>Grupy {  get; set; }
        public DbSet<Przedmioty> Przedmiot { get; set; }
        public DbSet<Oceny> Ocena { get; set; }

    }
}
