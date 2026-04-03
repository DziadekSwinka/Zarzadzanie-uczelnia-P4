using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarzadzanie_uczelnia
{
    internal class Kierunek
    {
        public ICollection<Grupa> Grupy { get; set; }
        public int ID { get; set; }
        public string? Nazwa { get; set; }
    }
}
