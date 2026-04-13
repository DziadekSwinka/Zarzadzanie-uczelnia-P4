using System.ComponentModel.DataAnnotations;

namespace Zarzadzanie_uczelnia
{
    public class Oceny
    {
        [Key]
        public int ID { get; set; }
        public int WartoscOceny { get; set; }
        public DateOnly DataWystawienia { get; set; }
        public Przedmioty Przedmiot { get; set; }
    }
}