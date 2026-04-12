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
        }

        private void Add_Group(object sender, RoutedEventArgs e)
        {

        }
    }
}
