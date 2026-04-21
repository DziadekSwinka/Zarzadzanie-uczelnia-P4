using System.ComponentModel.DataAnnotations;

namespace Zarzadzanie_uczelnia
{
    public class Przedmioty
    {
        [Required]
        public int ECTS { get; set; } = 1;
        [Key]
        [Required]
        public int ID { get; set; }
        public string? Nazwa { get; set; }
    }
}