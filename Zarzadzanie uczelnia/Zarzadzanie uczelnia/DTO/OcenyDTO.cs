namespace Zarzadzanie_uczelnia.DTO
{
    internal class OcenyDTO
    {
        public int ID { get; set; }
        public int WartoscOceny { get; set; }
        public DateOnly DataWystawienia { get; set; }
        public string Przedmiot { get; set; }

        public int StudentID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
