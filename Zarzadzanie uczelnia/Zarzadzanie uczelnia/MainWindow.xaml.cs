using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Zarzadzanie_uczelnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  
            WczytajKierunki();
            WczytajStudentow();
        }
        public void WczytajKierunki()
        {
            using (var db = new UczelniaContext())
            {
                var opcje =db.Kierunki.Select(k => k.Nazwa).ToList();

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
                        s.Rocznik
                    })
                    .Distinct()
                    .ToList();

                StudenciGrid.ItemsSource = studenci;
            }
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            using (var context = new UczelniaContext())
            {
                var student = new Student
                {
                    Imie = ImieBox.Text,
                    Nazwisko = NazwiskoBox.Text,
                    Email = EmailBox.Text,
                    NrTelefonu = Convert.ToInt32(TelefonBox.Text)
                };

                context.Studenci.Add(student);
                context.SaveChanges();
            }
            WczytajStudentow();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            var placeholderTexts = new[] { "Imię", "Nazwisko", "NrTelefonu", "Email" };
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
    }
}