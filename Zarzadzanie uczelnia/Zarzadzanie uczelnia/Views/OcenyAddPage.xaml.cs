using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zarzadzanie_uczelnia.View_Models;

namespace Zarzadzanie_uczelnia.Views
{
    /// <summary>
    /// Logika interakcji dla klasy OcenyAddPage.xaml
    /// </summary>
    public partial class OcenyAddPage : Page
    {
        private OcenyViewModel viewModel;
        public OcenyAddPage()
        {
            viewModel = new OcenyViewModel();
            DataContext = viewModel;
            InitializeComponent();
            viewModel.loadGrupy();
            viewModel.loadKierunki();
            viewModel.loadPrzedmioty();
            viewModel.loadStudenci();
        }
        private void DodajOcene_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DodajOcene();
        }
    }
}
