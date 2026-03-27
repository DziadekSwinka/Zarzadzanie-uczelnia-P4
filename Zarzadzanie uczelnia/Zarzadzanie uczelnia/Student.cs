using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarzadzanie_uczelnia
{
    internal class Student
    {
        public Student()
        {
            Ocena = new List<Oceny>();
        }
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }
        public int Rocznik { get; set; }
        public string? Email { get; set; }
        public int? NrTelefonu { get; set; }
        public ICollection<Oceny>Ocena{ get; set; }   
    }
}
