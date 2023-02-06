using FluentValidation;
using Restaurant.Application.Authentication.Commands.Register;

namespace Restaurant.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<RegisterCommand>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}
