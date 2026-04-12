using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zarzadzanie_uczelnia.Models;

namespace Zarzadzanie_uczelnia.View_Models
{
    internal class GroupViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string nazwaGrupy;
        public string NazwaGrupy
        {
            get => nazwaGrupy;
            set { nazwaGrupy = value; OnPropertyChanged(nameof(NazwaGrupy)); }
        }
        public ObservableCollection<GrupyDTO> Grupy { get; set; } = new();
        public void WczytajGrupe()
        {
            using (var db = new UczelniaContext())
            {
                Grupy.Clear();
                var grupy = db.Grupy
                    .Select(g => new GrupyDTO
                    {
                        ID = g.ID,
                        Nazwa = g.Nazwa,
                        KierunekNazwa = g.Kierunek.Nazwa
                    })
                    .ToList();

                foreach (var g in grupy)
                {
                    Grupy.Add(g);
                }
            }
        }
    }

}
