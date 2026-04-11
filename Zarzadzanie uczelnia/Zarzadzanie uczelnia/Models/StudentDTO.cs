namespace Zarzadzanie_uczelnia.Models
{
    public class StudentDto
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string NrTelefonu { get; set; }
        public int Rok_Urodzenia { get; set; }
    }
}