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
            .NotEmpty()
            .MinimumLength(7)
            .MaximumLength(20)
            .WithMessage("Niepoprawny numer telefonu");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Niepoprawny email");

        RuleFor(x => x.WybranyKierunek)
            .NotEmpty()
            .WithMessage("Wybierz kierunek");

        RuleFor(x => x.Rok)
            .Must(r => int.TryParse(r, out int rok) && rok >= 1900 && rok <= DateTime.Now.Year)
            .WithMessage("Niepoprawny rok urodzenia");
    }
}