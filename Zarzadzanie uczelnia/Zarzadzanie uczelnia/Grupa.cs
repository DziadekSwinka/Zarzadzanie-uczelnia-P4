using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarzadzanie_uczelnia
{
    internal class Grupa
    {
        public string? Nazwa { get; set; }
        [Key]
        public int ID { get; set; }
        public ICollection<Student> Studenci { get; set; }
        public Kierunek Kierunek { get; set; }
    }
}
