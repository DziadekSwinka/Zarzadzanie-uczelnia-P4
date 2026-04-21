using System.Windows.Controls;
using Zarzadzanie_uczelnia.View_Models;

namespace Zarzadzanie_uczelnia.Views
{
    /// <summary>
    /// Logika interakcji dla klasy OcenyPage.xaml
    /// </summary>
    public partial class OcenyPage : Page
    {
        private StudentViewModel viewModel;
        public OcenyPage()
        {
            viewModel = new StudentViewModel();
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
