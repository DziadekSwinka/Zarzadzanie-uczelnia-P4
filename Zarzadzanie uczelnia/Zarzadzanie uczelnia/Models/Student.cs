using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarzadzanie_uczelnia.Models
{
    internal class Student : IDataErrorInfo
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
        public string? NrTelefonu { get; set; }
        public ICollection<Oceny> Ocena { get; set; }
        public int? GrupaID { get; set; }
        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Imie":
                        if (string.IsNullOrWhiteSpace(Imie))
                            return "Imię jest wymagane";
                        break;

                    case "Nazwisko":
                        if (string.IsNullOrWhiteSpace(Nazwisko))
                            return "Nazwisko jest wymagane";
                        break;

                    case "Email":
                        if (!string.IsNullOrWhiteSpace(Email) && !Email.Contains("@"))
                            return "Email musi zawierać @";
                        break;

                    case "NrTelefonu":
                        if (NrTelefonu != null && NrTelefonu.Length < 9)
                            return "Numer telefonu za krótki";
                        break;
                }

                return null;
            }
        }
    }
}
