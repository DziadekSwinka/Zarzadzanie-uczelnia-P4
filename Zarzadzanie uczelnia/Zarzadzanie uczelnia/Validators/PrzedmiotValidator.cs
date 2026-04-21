using FluentValidation;
using Zarzadzanie_uczelnia.View_Models;

namespace Zarzadzanie_uczelnia.Validators
{
    public class PrzedmiotValidator : AbstractValidator<PrzedmiotViewModel>
    {
        public PrzedmiotValidator()
        {
            RuleFor(x => x.Nazwa)
                .NotEmpty().WithMessage("Podaj nazwę przedmiotu");

            RuleFor(x => x.ECTS)
                .NotEmpty().WithMessage("Podaj ECTS")
                .Must(x => int.TryParse(x, out int v) && v > 0)
                .WithMessage("ECTS musi być liczbą > 0");

            RuleFor(x => x.WybranyKierunek)
                .NotEmpty().WithMessage("Wybierz kierunek");
        }
    }
}