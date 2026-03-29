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

namespace Zarzadzanie_uczelnia
{
    /// <summary>
    /// Logika interakcji dla klasy GrupyPage.xaml
    /// </summary>
    public partial class GrupyPage : Page
    {
        public GrupyPage()
        {
            InitializeComponent();
            WczytajGrupe();
        }
        private void WczytajGrupe()
        {
            using (var db = new UczelniaContext())
            {
                var grupy = db.Grupy
                    .Select(g => new
                    {
                        g.ID,
                        g.Nazwa,
                        KierunekNazwa = g.Kierunek.Nazwa
                    })
                    .Distinct()
                    .ToList();

                GrupyGrid.ItemsSource = grupy;
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            var placeholderTexts = new[] { "Nazwa grupy" };
            if (placeholderTexts.Contains(textBox.Text))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
