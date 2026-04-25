using Zarzadzanie_uczelnia.Models;

namespace Zarzadzanie_uczelnia
{
    public class Oceny
    {
        public int ID { get; set; }
        public int WartoscOceny { get; set; }
        public DateOnly DataWystawienia { get; set; }

        public int PrzedmiotID { get; set; }
        public Przedmioty Przedmiot { get; set; }

        public int GrupaID { get; set; }
        public Grupa Grupa { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}