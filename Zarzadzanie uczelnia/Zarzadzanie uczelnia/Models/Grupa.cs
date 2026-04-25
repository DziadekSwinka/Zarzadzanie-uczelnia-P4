using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Zarzadzanie_uczelnia.Models;

namespace Zarzadzanie_uczelnia
{
    public class Grupa
    {
        public int ID { get; set; }
        public string? Nazwa { get; set; }

        public int KierunekID { get; set; }
        public Kierunek Kierunek { get; set; }

        public ICollection<Student> Studenci { get; set; } = new List<Student>();
        public ICollection<Oceny> Oceny { get; set; } = new List<Oceny>();
    }
}
