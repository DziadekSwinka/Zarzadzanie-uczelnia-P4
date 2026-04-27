using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarzadzanie_uczelnia.DTO
{
    public class StudentViewDTO
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }

        public string FullName => Imie + " " + Nazwisko;
        public string Display => $"{ID} - {Imie} {Nazwisko}";
    }
}
