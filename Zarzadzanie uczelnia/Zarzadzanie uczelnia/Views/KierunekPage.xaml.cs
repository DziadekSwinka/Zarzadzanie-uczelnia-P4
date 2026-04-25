using System.Windows;
using System.Windows.Controls;
using Zarzadzanie_uczelnia.View_Models;

namespace Zarzadzanie_uczelnia.Views
{
    public partial class KierunekPage : Page
    {
        private KierunekViewModel vm;

        public KierunekPage()
        {
            InitializeComponent();
            vm = new KierunekViewModel();
            DataContext = vm;
        }

        private void DodajKierunek_Click(object sender, RoutedEventArgs e)
        {
            vm.DodajKierunek();
        }
    }
}