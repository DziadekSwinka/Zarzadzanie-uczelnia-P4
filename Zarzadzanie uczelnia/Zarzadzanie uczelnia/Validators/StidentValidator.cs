using FluentValidation;
using Zarzadzanie_uczelnia.View_Models;

public class StudentValidator : AbstractValidator<StudentViewModel>
{
    public StudentValidator()
    {
        RuleFor(x => x.Imie)
            .NotEmpty().WithMessage("Podaj imię");

        RuleFor(x => x.Nazwisko)
            .NotEmpty().WithMessage("Podaj nazwisko");

        RuleFor(x => x.NrTelefonu)
            .Matches(@"^\+?\d{7,15}$")
            .WithMessage("Niepoprawny numer telefonu");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Niepoprawny email");

        RuleFor(x => x.Kierunek)
            .NotEmpty()
            .WithMessage("Wybierz kierunek");

        RuleFor(x => x.Rocznik)
            .InclusiveBetween(1900, DateTime.Now.Year)
            .WithMessage("Niepoprawny rok urodzenia");
    }
}