using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Text.RegularExpressions;
using Zarzadzanie_uczelnia.Models;
using Zarzadzanie_uczelnia.View_Models;

namespace Zarzadzanie_uczelnia
{
    /// <summary>
    /// Logika interakcji dla klasy StudenciPage.xaml
    /// </summary>
    public partial class StudenciPage : Page
    {
        private StudentViewModel viewModel;
        public StudenciPage()
        {
            viewModel = new StudentViewModel();
            DataContext = viewModel;
            InitializeComponent();
            viewModel.loadKierunki();
            viewModel.LoadStudents();

            viewModel.PrzejdzDoGrup += () =>
            {
                NavigationService.Navigate(new GrupyPage());
            };
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddStudent();
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
