using FluentValidation;
using Zarzadzanie_uczelnia.View_Models;

namespace Zarzadzanie_uczelnia.Validators
{
    public class KierunekValidator : AbstractValidator<KierunekViewModel>
    {
        public KierunekValidator()
        {
            RuleFor(x => x.Nazwa)
                .NotEmpty().WithMessage("Podaj nazwę kierunku")
                .MinimumLength(3).WithMessage("Nazwa musi mieć min. 3 znaki");
        }
    }
}