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
            WczytajStudentow();
        }

        private void WczytajStudentow()
        {
            using (var db = new UczelniaContext())
            {
                StudenciGrid.ItemsSource = db.Studenci.ToList();
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}