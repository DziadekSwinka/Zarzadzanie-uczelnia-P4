using System.Windows;
using System.Windows.Controls;
using Zarzadzanie_uczelnia.View_Models;

namespace Zarzadzanie_uczelnia
{
    /// <summary>
    /// Logika interakcji dla klasy GrupyPage.xaml
    /// </summary>
    public partial class GrupyPage : Page
    {
        private GroupViewModel viewModel;
        public GrupyPage()
        {
            viewModel = new GroupViewModel();  
            DataContext = viewModel;
            InitializeComponent();
            viewModel.WczytajGrupe();
            viewModel.loadKierunki();
        }

        private void Add_Group(object sender, RoutedEventArgs e)
        {
            viewModel.AddGroup();
        }
    }
}
