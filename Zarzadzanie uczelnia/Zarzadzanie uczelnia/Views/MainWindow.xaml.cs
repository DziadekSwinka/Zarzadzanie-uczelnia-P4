using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Zarzadzanie_uczelnia.Views;

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
            MainFrame.Navigate(new StudenciPage());
        }

        public void Navigate(Page page)
        {
            MainFrame.Navigate(page);
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        private void Grupy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GrupyPage());
        }

        private void Studenci_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudenciPage());
        } 
        private void Oceny_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OcenyPage());
        } 
        private void DodajOcene_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new OcenyAddPage());
        }
        private void Przedmioty_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PrzedmiotPage());
        }
    }
}