using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
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
    private ObservableCollection<StudentViewDTO> studenci;
    public ObservableCollection<StudentViewDTO> Studenci
    {
        get => studenci;
        set { studenci = value; OnPropertyChanged(nameof(Studenci)); }
    }

    private StudentViewDTO wybranyStudent;
    public StudentViewDTO WybranyStudent
    {
        get => wybranyStudent;
        set { wybranyStudent = value; OnPropertyChanged(nameof(WybranyStudent)); }
    }

    private string wybranaGrupa;
    public string WybranaGrupa
    {
        get => wybranaGrupa;
        set { wybranaGrupa = value; OnPropertyChanged(nameof(WybranaGrupa)); }
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

    private string wybranyPrzedmiot;
    public string WybranyPrzedmiot
    {
        get => wybranyPrzedmiot;
        set { wybranyPrzedmiot = value; OnPropertyChanged(nameof(WybranyPrzedmiot)); }
    }

    private ObservableCollection<string> przedmioty;
    public ObservableCollection<string> Przedmioty
    {
        get => przedmioty;
        set { przedmioty = value; OnPropertyChanged(nameof(Przedmioty)); }
    }

    private int wartoscOceny;
    public int WartoscOceny
    {
        get => wartoscOceny;
        set
        {
            wartoscOceny = value;
            OnPropertyChanged(nameof(WartoscOceny));
        }
    }
    public string FilterStudentId { get; set; }
    public string FilterPrzedmiot { get; set; }
    public void FiltrujOceny()
{
    using var db = new UczelniaContext();

    var query = db.Ocena.AsQueryable();

    if (!string.IsNullOrWhiteSpace(FilterStudentId))
    {
        if (int.TryParse(FilterStudentId, out int studentId))
        {
            query = query.Where(o => o.StudentID == studentId);
        }
    }

    if (!string.IsNullOrWhiteSpace(FilterPrzedmiot))
    {
        query = query.Where(o => o.Przedmiot.Nazwa.Contains(FilterPrzedmiot));
    }

    Oceny.Clear();

        var lista = query
        .Select(o => new OcenyDTO
        {
            ID = o.ID,
            WartoscOceny = o.WartoscOceny,
            Przedmiot = o.Przedmiot.Nazwa,
            StudentID = o.StudentID,
            Imie = o.Student.Imie,
            Nazwisko = o.Student.Nazwisko
        })
        .ToList();

        foreach (var o in lista)
    {
        Oceny.Add(o);
    }
}
    public void loadStudenci()
    {
        using var db = new UczelniaContext();

        Studenci = new ObservableCollection<StudentViewDTO>(
            db.Studenci.Select(s => new StudentViewDTO
            {
                ID = s.ID,
                Imie = s.Imie,
                Nazwisko = s.Nazwisko
            }).ToList()
        );

        OnPropertyChanged(nameof(Studenci));
    }
    public void loadPrzedmioty()
    {
        using var db = new UczelniaContext();

        Przedmioty = new ObservableCollection<string>(
            db.Przedmiot.Select(p => p.Nazwa).ToList()
        );

        OnPropertyChanged(nameof(Przedmioty));
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

    public void DodajOcene()
    {
        using var db = new UczelniaContext();

        if (WybranyStudent == null || WybranyPrzedmiot == null || WybranaGrupa == null)
        {
            MessageBox.Show("Uzupełnij wszystkie dane.");
            return;
        }

        var student = db.Studenci.FirstOrDefault(s => s.ID == WybranyStudent.ID);
        var przedmiot = db.Przedmiot.FirstOrDefault(p => p.Nazwa == WybranyPrzedmiot);

        var grupa = db.Grupy
            .Include(g => g.Kierunek)
            .FirstOrDefault(g => (g.Nazwa + " (" + g.Kierunek.Nazwa + ")") == WybranaGrupa);

        if (student == null || przedmiot == null || grupa == null)
        {
            MessageBox.Show("Błąd danych.");
            return;
        }

        if (student.GrupaID != grupa.ID)
        {
            MessageBox.Show("Ten student nie należy do wybranej grupy.");
            return;
        }

        bool przedmiotOK = db.Kierunki
            .Include(k => k.Przedmioty)
            .Any(k => k.ID == grupa.KierunekID &&
                      k.Przedmioty.Any(p => p.ID == przedmiot.ID));

        if (!przedmiotOK)
        {
            MessageBox.Show("Ten przedmiot nie należy do kierunku tej grupy.");
            return;
        }

        if (WartoscOceny < 2 || WartoscOceny > 5)
        {
            MessageBox.Show("Ocena musi być w zakresie 2–5.");
            return;
        }

        var ocena = new Oceny
        {
            WartoscOceny = WartoscOceny,
            PrzedmiotID = przedmiot.ID,
            GrupaID = grupa.ID,
            StudentID = student.ID,
            DataWystawienia = DateOnly.FromDateTime(DateTime.Now)
        };

        db.Ocena.Add(ocena);
        db.SaveChanges();

        MessageBox.Show("Ocena dodana poprawnie.");
    }

    public ObservableCollection<OcenyDTO> Oceny { get; set; } = new();

    public void wczytajOceny()
    {
        using var db = new UczelniaContext();

        Oceny.Clear();

        var oceny = db.Ocena
            .Select(o => new OcenyDTO
            {
                ID = o.ID,
                WartoscOceny = o.WartoscOceny,
                Przedmiot = o.Przedmiot.Nazwa
            })
            .ToList();

        foreach (var o in oceny)
        {
            Oceny.Add(o);
        }
    }
}