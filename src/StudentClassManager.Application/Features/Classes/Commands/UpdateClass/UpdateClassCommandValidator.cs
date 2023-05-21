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
            .NotEmpty()
            .MaximumLength(45);

        RuleFor(p => p.Year)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.Now.Year);
    }
}