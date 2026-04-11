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
using Zarzadzanie_uczelnia;

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
    }
}