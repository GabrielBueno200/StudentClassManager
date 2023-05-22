using FluentValidation;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Classes.Commands.UpdateClass;

public class UpdateClassCommandValidator : AbstractValidator<UpdateClassCommand>
{
    public UpdateClassCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty();

        RuleFor(p => p.ClassName)
            .NotNull()
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(45).WithMessage("Nome pode conter no máximo 45 caracteres");

        RuleFor(p => p.Year)
            .NotNull()
            .NotEmpty().WithMessage("Ano é obrigatório")
            .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Ano deve ser maior ou igual ao atual");;
    }
}