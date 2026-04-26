using System.Windows.Controls;
using Zarzadzanie_uczelnia.View_Models;

namespace Zarzadzanie_uczelnia.Views
{
    /// <summary>
    /// Logika interakcji dla klasy OcenyPage.xaml
    /// </summary>
    public partial class OcenyPage : Page
    {
        private OcenyViewModel viewModel;
        public OcenyPage()
        {
            viewModel = new OcenyViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }

        private void Filtruj(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel.FiltrujOceny();
        }
    }
}
