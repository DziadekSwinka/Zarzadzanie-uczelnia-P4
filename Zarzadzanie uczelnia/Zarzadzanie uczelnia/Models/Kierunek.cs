namespace Zarzadzanie_uczelnia
{
    public class Kierunek
    {
        public int ID { get; set; }
        public string? Nazwa { get; set; }

        public ICollection<Grupa> Grupy { get; set; } = new List<Grupa>();
        public ICollection<Przedmioty> Przedmioty { get; set; } = new List<Przedmioty>();
    }
}
