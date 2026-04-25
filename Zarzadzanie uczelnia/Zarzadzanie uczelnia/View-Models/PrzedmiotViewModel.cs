using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Zarzadzanie_uczelnia.Validators;

namespace Zarzadzanie_uczelnia.View_Models
{
    public class PrzedmiotViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<string> Kierunki { get; set; } = new();

        private string nazwa;
        public string Nazwa
        {
            get => nazwa;
            set { nazwa = value; OnPropertyChanged(nameof(Nazwa)); }
        }

        private string ects;
        public string ECTS
        {
            get => ects;
            set { ects = value; OnPropertyChanged(nameof(ECTS)); }
        }

        private string wybranyKierunek;
        public string WybranyKierunek
        {
            get => wybranyKierunek;
            set { wybranyKierunek = value; OnPropertyChanged(nameof(WybranyKierunek)); }
        }

        public void LoadKierunki()
        {
            using var db = new UczelniaContext();

            Kierunki = new ObservableCollection<string>(
                db.Kierunki.Select(k => k.Nazwa).ToList()
            );

            OnPropertyChanged(nameof(Kierunki));
        }

        private string Validate()
        {
            var validator = new PrzedmiotValidator();
            var result = validator.Validate(this);

            if (result.IsValid)
                return "";

            return string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
        }

        public void DodajPrzedmiot()
        {
            var error = Validate();

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }

            using var db = new UczelniaContext();

            var kierunek = db.Kierunki
                .FirstOrDefault(k => k.Nazwa == WybranyKierunek);

            if (kierunek == null)
            {
                MessageBox.Show("Błąd kierunku");
                return;
            }

            int ectsVal = int.Parse(ECTS);

            var istnieje = db.Przedmiot
                .Any(p => p.Nazwa == Nazwa && p.ID == kierunek.ID);

            if (istnieje)
            {
                MessageBox.Show("Przedmiot już istnieje w tym kierunku");
                return;
            }

            db.Przedmiot.Add(new Przedmioty
            {
                Nazwa = Nazwa,
                ECTS = ectsVal,
                KierunekID = kierunek.ID
            });

            db.SaveChanges();

            MessageBox.Show("Dodano przedmiot");
        }
    }
}