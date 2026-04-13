using FluentValidation;
using Zarzadzanie_uczelnia.View_Models;

public class GroupValidator : AbstractValidator<GroupViewModel>
{
    public GroupValidator()
    {
       RuleFor(x => x.NazwaGrupy)
            .NotEmpty()
            .WithMessage("Podaj nazwę grupy");

        RuleFor(x => x.WybranyKierunek)
            .NotEmpty()
            .WithMessage("Wybierz kierunek");
    }
}