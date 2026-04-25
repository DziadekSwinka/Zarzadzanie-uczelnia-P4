namespace Zarzadzanie_uczelnia
{
    public class Przedmioty
    {
        public int ID { get; set; }
        public string? Nazwa { get; set; }
        public int ECTS { get; set; } = 1;

        public int KierunekID { get; set; }
        public Kierunek Kierunek { get; set; }

        public ICollection<Oceny> Oceny { get; set; } = new List<Oceny>();
    }
}