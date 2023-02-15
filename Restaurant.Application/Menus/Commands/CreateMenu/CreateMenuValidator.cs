using FluentValidation;
using Restaurant.Application.Authentication.Commands.Register;

namespace Restaurant.Application.Menus.Commands.CreateMenu;

public class CreateMenuValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.MenuSections).NotEmpty();        
    }
}