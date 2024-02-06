using Application.ViewModel;
using FluentValidation;

namespace Application.Validator;

public class AuthValidator : AbstractValidator<AuthViewModel>
{
    public AuthValidator()
    {
        RuleFor(x => x.UserName).NotNull().WithMessage($"'UserName' não pode ser nulo.");

        RuleFor(x => x.UserName).NotEmpty().WithMessage($"'UserName' não pode ser vazio.");

        RuleFor(x => x.Password).NotNull().WithMessage($"'Password' não pode ser nulo.");

        RuleFor(x => x.Password).NotEmpty().WithMessage($"'Password' não pode ser vazio.");
    }
}
