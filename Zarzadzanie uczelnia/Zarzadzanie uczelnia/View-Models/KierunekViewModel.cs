using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Zarzadzanie_uczelnia.Validators;

namespace Zarzadzanie_uczelnia.View_Models
{
    public class KierunekViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string nazwa;
        public string Nazwa
        {
            get => nazwa;
            set { nazwa = value; OnPropertyChanged(nameof(Nazwa)); }
        }
        public ObservableCollection<Kierunek> KierunkiList { get; set; } = new();
        public void LoadKierunki()
        {
            using var db = new UczelniaContext();

            KierunkiList.Clear();

            var lista = db.Kierunki.ToList();

            foreach (var k in lista)
            {
                KierunkiList.Add(k);
            }
        }
        private string Validate()
        {
            var validator = new KierunekValidator();
            var result = validator.Validate(this);

            if (result.IsValid)
                return "";

            return string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
        }

        public void DodajKierunek()
        {
            var error = Validate();

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }

            using var db = new UczelniaContext();

            var istnieje = db.Kierunki
                .Any(k => k.Nazwa == Nazwa);

            if (istnieje)
            {
                MessageBox.Show("Taki kierunek już istnieje");
                return;
            }

            db.Kierunki.Add(new Kierunek
            {
                Nazwa = Nazwa
            });

            db.SaveChanges();

            MessageBox.Show("Dodano kierunek");

            Nazwa = "";
            OnPropertyChanged(nameof(Nazwa));
        }
    }
}