using System.Windows;
using System.Windows.Controls;
using Zarzadzanie_uczelnia.View_Models;

namespace Zarzadzanie_uczelnia.Views
{
    public partial class PrzedmiotPage : Page
    {
        private PrzedmiotViewModel viewModel;

        public PrzedmiotPage()
        {
            InitializeComponent();
            viewModel = new PrzedmiotViewModel();
            DataContext = viewModel;
            viewModel.LoadKierunki();
            viewModel.LoadPrzedmioty();
        }

        private void DodajPrzedmiot_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DodajPrzedmiot();
            viewModel.LoadPrzedmioty();
        }
    }
}