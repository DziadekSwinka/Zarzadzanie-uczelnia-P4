using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zarzadzanie_uczelnia.Models;

namespace Zarzadzanie_uczelnia.View_Models
{
    internal class OcenyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<OcenyDTO> Oceny { get; set; } = new();
        public void wczytajOceny()
        {
            using (var db = new UczelniaContext())
            {
                Oceny.Clear();
                var oceny = db.Ocena
                    .Select(o => new OcenyDTO
                    {
                        ID = o.ID,
                        WartoscOceny = o.WartoscOceny,
                        Przedmiot = o.Przedmiot.Nazwa,
                    })
                    .ToList();
                foreach (var g in oceny)
                {
                    Oceny.Add(g);
                }
            }
        }
    }
}
