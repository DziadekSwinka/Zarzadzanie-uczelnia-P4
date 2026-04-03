using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Text.RegularExpressions;

namespace Zarzadzanie_uczelnia
{
    /// <summary>
    /// Logika interakcji dla klasy StudenciPage.xaml
    /// </summary>
    public partial class StudenciPage : Page
    {
        public StudenciPage()
        {
            InitializeComponent();
            WczytajKierunki();
            WczytajStudentow();
            //DataContext = new Student();
        }

        public void WczytajKierunki()
        {
            using (var db = new UczelniaContext())
            {
                var opcje = db.Kierunki.Select(k => k.Nazwa).ToList();

                Kierunek.Items.Clear();
                var placeholder = new ComboBoxItem
                {
                    Content = "Kierunek",
                    IsEnabled = false,
                    Foreground = Brushes.Gray
                };
                Kierunek.Items.Add(placeholder);

                foreach (var opcja in opcje)
                    Kierunek.Items.Add(new ComboBoxItem { Content = opcja });

                Kierunek.SelectedIndex = 0;

                Kierunek.SelectionChanged += (s, e) =>
                {
                    if (Kierunek.SelectedIndex == 0) return;

                    if (Kierunek.Items.Contains(placeholder))
                        Kierunek.Items.Remove(placeholder);
                };
            }
        }

        private void WczytajStudentow()
        {
            using (var db = new UczelniaContext())
            {
                var studenci = db.Studenci
                    .Select(s => new
                    {
                        s.ID,
                        s.Imie,
                        s.Nazwisko,
                        s.NrTelefonu,
                        s.Email,
                        Rok_Urodzenia = s.Rocznik
                    })
                    .Distinct()
                    .ToList();

                StudenciGrid.ItemsSource = studenci;
            }
        }
        private string ValidateStudent()
        {
            string blad = "";
            if (string.IsNullOrWhiteSpace(ImieBox.Text))
                blad += "Podaj imię\n";
            if (string.IsNullOrWhiteSpace(NazwiskoBox.Text))
                blad += "Podaj nazwisko\n";
            if (!Regex.IsMatch(TelefonBox.Text, @"^\+?\d{ 7,15}$"))
                blad += "Niepoprawny numer teleofnu\n";
            if (!Regex.IsMatch(EmailBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                blad += "Niepoprawny email\n";
            if (Kierunek.SelectedIndex == 0)
                blad += "Wybierz kierunek\n";
            if (!int.TryParse(RokBox.Text, out int rok) || rok < 1900 || rok > DateTime.Now.Year)
                blad += "Niepoprawny rok urodzenia\n";
            return blad;
        }
        private void AddStudent(object sender, RoutedEventArgs e)
        {
            if (ValidateStudent() is string error)
            {
                MessageBox.Show(error);
                return;
            }
            int studentId;
            using (var context = new UczelniaContext())
            {
                var student = new Student
                {
                    Imie = ImieBox.Text,
                    Nazwisko = NazwiskoBox.Text,
                    Email = EmailBox.Text,
                    NrTelefonu = TelefonBox.Text,
                    Rocznik = int.TryParse(RokBox.Text, out int rok) ? rok : 0
                };
                context.Studenci.Add(student);
                context.SaveChanges();
                studentId = student.ID;
            }
            DodajDoGrupy(studentId);
            WczytajStudentow();
        }

        private void DodajDoGrupy(int studentId)
        {
            if (AutoGrupaCheckBox.IsChecked == true)
            {
                using (var context = new UczelniaContext())
                {
                    var wybranyKierunek = (Kierunek.SelectedItem as ComboBoxItem)?.Content?.ToString();
                    if (string.IsNullOrEmpty(wybranyKierunek)) return;

                    var grupa = context.Grupy
                        .Where(g => g.Kierunek.Nazwa == wybranyKierunek)
                        .OrderBy(g => g.ID)
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
            else
            {
                NavigationService.Navigate(new GrupyPage());
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            var placeholderTexts = new[] { "Imię", "Nazwisko", "Nr Telefonu", "Email", "Rok urodzenia" };
            if (placeholderTexts.Contains(textBox.Text))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            /*if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                ((TextBox)sender).Text = "Imię";
                ((TextBox)sender).Foreground = Brushes.Gray;
            }*/
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
