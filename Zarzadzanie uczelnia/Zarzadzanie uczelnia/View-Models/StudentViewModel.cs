using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Zarzadzanie_uczelnia.DTO;
using Zarzadzanie_uczelnia.Models;

namespace Zarzadzanie_uczelnia.View_Models
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Rok { get; set; }

        private string imie;
        public string Imie
        {
            get => imie;
            set { imie = value; OnPropertyChanged(nameof(Imie)); }
        }

        private string nazwisko;
        public string Nazwisko
        {
            get => nazwisko;
            set { nazwisko = value; OnPropertyChanged(nameof(Nazwisko)); }
        }

        private string nrTelefonu;
        public string NrTelefonu
        {
            get => nrTelefonu;
            set { nrTelefonu = value; OnPropertyChanged(nameof(NrTelefonu)); }
        }

        private string email;
        public string Email
        {
            get => email;
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        private int rocznik;
        public int Rocznik
        {
            get => rocznik;
            set { rocznik = value; OnPropertyChanged(nameof(Rocznik)); }
        }

        private string kierunek;
        public string Kierunek
        {
            get => kierunek;
            set { kierunek = value; OnPropertyChanged(nameof(Kierunek)); }
        }

        public ObservableCollection<string> Kierunki { get; set; }

        private string wybranyKierunek;
        public string WybranyKierunek
        {
            get => wybranyKierunek;
            set { wybranyKierunek = value; OnPropertyChanged(nameof(WybranyKierunek)); }
        }

        private bool autoGrupa;
        public bool AutoGrupa
        {
            get => autoGrupa;
            set { autoGrupa = value; OnPropertyChanged(nameof(AutoGrupa)); }
        }

        public ObservableCollection<StudentDto> Studenci { get; set; } = new();

        public event Action PrzejdzDoGrup;

        public void loadKierunki()
        {
            using var db = new UczelniaContext();

            Kierunki = new ObservableCollection<string>(
                db.Kierunki.Select(k => k.Nazwa).ToList()
            );

            OnPropertyChanged(nameof(Kierunki));
        }

        public void LoadStudents()
        {
            using var db = new UczelniaContext();

            Studenci.Clear();

            var lista = db.Studenci
                .Select(s => new StudentDto
                {
                    ID = s.ID,
                    Imie = s.Imie,
                    Nazwisko = s.Nazwisko,
                    Email = s.Email,
                    NrTelefonu = s.NrTelefonu,
                    Rok_Urodzenia = s.Rocznik
                })
                .ToList();

            foreach (var s in lista)
            {
                Studenci.Add(s);
            }
        }

        private string ValidateStudent()
        {
            var validator = new StudentValidator();
            var result = validator.Validate(this);

            if (result.IsValid)
                return "";

            return string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
        }

        public void AddStudent()
        {
            var error = ValidateStudent();

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }

            int studentId;

            using (var context = new UczelniaContext())
            {
                var student = new Student
                {
                    Imie = Imie,
                    Nazwisko = Nazwisko,
                    Email = Email,
                    NrTelefonu = NrTelefonu,
                    Rocznik = int.TryParse(Rok, out int rok) ? rok : 0
                };

                context.Studenci.Add(student);
                context.SaveChanges();

                studentId = student.ID;
            }

            DodajDoGrupy(studentId);
            LoadStudents();
        }

        private void DodajDoGrupy(int studentId)
        {

            using (var context = new UczelniaContext())
            {
                if (string.IsNullOrEmpty(wybranyKierunek)) return;

                var grupa = context.Grupy
                    .Where(g => g.Kierunek.Nazwa == wybranyKierunek)
                    .OrderBy(g => g.Studenci.Count)
                    .FirstOrDefault();

                if (grupa != null)
                {
                    var studentZBazy = context.Studenci.FirstOrDefault(s => s.ID == studentId);

                    if (studentZBazy != null)
                    {
                        studentZBazy.GrupaID = grupa.ID;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}