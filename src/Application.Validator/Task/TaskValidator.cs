using Application.ViewModel;
using FluentValidation;

namespace Application.Validator;

public class TaskValidator : AbstractValidator<InputTaskViewModel>
{
    public TaskValidator()
    {
        RuleFor(x => x.Title).NotNull().WithMessage($"'Title' não pode ser nulo.");

        RuleFor(x => x.Title).NotEmpty().WithMessage($"'Title' não pode ser vazio.");

        RuleFor(x => x.Title).MaximumLength(100).WithMessage($"'Title': O tamanho máximo é de 100 caracteres");

        RuleFor(x => x.Description).NotNull().WithMessage($"'Description' não pode ser nulo.");

        RuleFor(x => x.Description).NotEmpty().WithMessage($"'Description' não pode ser vazio.");

        RuleFor(x => x.Title).MaximumLength(500).WithMessage($"'Description': O tamanho máximo é de 500 caracteres");

        RuleFor(x => x.Completed).NotNull().WithMessage($"'Completed' não pode ser nulo.");

        RuleFor(x => x.Completed).NotEmpty().WithMessage($"'Completed' não pode ser vazio.");
    }
}
