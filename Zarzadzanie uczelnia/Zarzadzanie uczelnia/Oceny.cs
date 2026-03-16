namespace Zarzadzanie_uczelnia
{
    public class Oceny
    {
        public ICollection<Przedmioty>Przedmiot { get; set; }
        public int ID { get; set; }
        public int WartoscOceny { get; set; }
        public DateOnly DataWystawienia { get; set; }
    }
}