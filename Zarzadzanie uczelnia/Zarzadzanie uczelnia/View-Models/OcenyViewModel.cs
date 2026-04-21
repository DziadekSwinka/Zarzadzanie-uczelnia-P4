using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Zarzadzanie_uczelnia.DTO;

namespace Zarzadzanie_uczelnia.View_Models;

internal class OcenyViewModel : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private string wybranaGrupa;
    public string WybranaGrupa
    {
        get => wybranaGrupa;
        set { wybranaGrupa = value; OnPropertyChanged(nameof(wybranaGrupa)); }
    }
    private ObservableCollection<string> grupa;
    public ObservableCollection<string> Grupy
    {
        get => grupa;
        set { grupa = value; OnPropertyChanged(nameof(Grupy)); }
    }
    private string wybranyKierunek;
    public string WybranyKierunek
    {
        get => wybranyKierunek;
        set { wybranyKierunek = value; OnPropertyChanged(nameof(WybranyKierunek)); }
    }
    private ObservableCollection<string> kierunki;
    public ObservableCollection<string> Kierunki
    {
        get => kierunki;
        set { kierunki = value; OnPropertyChanged(nameof(Kierunki)); }
    }
    public void loadKierunki()
    {
        using var db = new UczelniaContext();

        Kierunki = new ObservableCollection<string>(
            db.Kierunki.Select(k => k.Nazwa).ToList()
        );

        OnPropertyChanged(nameof(Kierunki));
    }
    public void loadGrupy()
    {
        using var db = new UczelniaContext();

        Grupy = new ObservableCollection<string>(
            db.Grupy
             .Select(g => g.Nazwa + " (" + g.Kierunek.Nazwa + ")")
             .ToList()
        );

        OnPropertyChanged(nameof(Grupy));
    }
    public ObservableCollection<OcenyDTO> Oceny { get; set; } = new();
    public void wczytajOceny()
    {
        using (var db = new UczelniaContext())
        {
            Oceny.Clear();
            var oceny = db.Ocena
                .Select(o => new OcenyDTO
                {
                    ID = o.ID,
                    WartoscOceny = o.WartoscOceny,
                    Przedmiot = o.Przedmiot.Nazwa,
                })
                .ToList();
            foreach (var g in oceny)
            {
                Oceny.Add(g);
            }
        }
    }
}
