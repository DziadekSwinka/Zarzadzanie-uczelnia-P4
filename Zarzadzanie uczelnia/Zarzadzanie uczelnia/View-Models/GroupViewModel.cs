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
        private string wybranyKierunek;
        public string WybranyKierunek
        {
            get => wybranyKierunek;
            set { wybranyKierunek = value; OnPropertyChanged(nameof(WybranyKierunek)); }
        }
        private ObservableCollection<string> kierunki;
        public ObservableCollection<string> Kierunki
        {
            get => kierunki;
            set { kierunki = value; OnPropertyChanged(nameof(Kierunki)); }
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
                        NazwaKierunku = g.Kierunek.Nazwa
                    })
                    .ToList();

                foreach (var g in grupy)
                {
                    Grupy.Add(g);
                }
            }
        }
        public void loadKierunki()
        {
            using var db = new UczelniaContext();

            Kierunki = new ObservableCollection<string>(
                db.Kierunki.Select(k => k.Nazwa).ToList()
            );

            OnPropertyChanged(nameof(Kierunki));
        }
        public void AddGroup()
        {
            //TODO: walidacja danych

            using (var db = new UczelniaContext())
            {
                var grupa = new Grupa
                {
                    Nazwa = this.NazwaGrupy,
                    Kierunek = db.Kierunki.FirstOrDefault(k => k.Nazwa == this.WybranyKierunek)
                };
                db.Grupy.Add(grupa);
                db.SaveChanges();
            }
        }
    }

}
