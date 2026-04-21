using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarzadzanie_uczelnia.DTO
{
    internal class PrzedmiotDTO
    {
        public int ECTS { get; set; } = 1;
        public int ID { get; set; }
        public string? Nazwa { get; set; }
    }
}
