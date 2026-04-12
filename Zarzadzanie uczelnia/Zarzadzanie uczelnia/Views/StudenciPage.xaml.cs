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
    }
}
