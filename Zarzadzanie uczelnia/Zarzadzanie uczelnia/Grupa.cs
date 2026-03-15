using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarzadzanie_uczelnia
{
    internal class Grupa
    {
        public string Nazwa { get; set; }
        public int ID { get; set; }
        public ICollection<Student> Studenci { get; set; }
    }
}
