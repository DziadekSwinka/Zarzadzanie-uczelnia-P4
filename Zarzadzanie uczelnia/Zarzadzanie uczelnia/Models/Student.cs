namespace Zarzadzanie_uczelnia.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public int Rocznik { get; set; }
        public string? Email { get; set; }
        public string? NrTelefonu { get; set; }

        public int? GrupaID { get; set; }
        public Grupa Grupa { get; set; }

        public ICollection<Oceny> Oceny { get; set; } = new List<Oceny>();
    }
}
