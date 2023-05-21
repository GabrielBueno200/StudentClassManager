using FluentValidation;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Classes.Commands.CreateClass;

public class CreateClassCommandValidator : AbstractValidator<CreateClassCommand>
{
    public CreateClassCommandValidator()
    {
        RuleFor(p => p.ClassName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(45);

        RuleFor(p => p.Year)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.Now.Year);

    }
}
