namespace Zarzadzanie_uczelnia.DTO
{
    internal class OcenyDTO
    {
        public int ID { get; set; }
        public int WartoscOceny { get; set; }
        public DateOnly DataWystawienia { get; set; }
        public string Przedmiot { get; set; }
    }
}
