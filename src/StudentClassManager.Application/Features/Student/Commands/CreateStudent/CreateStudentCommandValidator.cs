using FluentValidation;

namespace StudentClassManager.Application.Features.Student.Commands.CreateStudent;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(255);
        RuleFor(p => p.UserName).NotNull().NotEmpty().MaximumLength(45);
        RuleFor(p => p.Password)
            .MinimumLength(8)
            .Matches(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$")
            .WithMessage("Senha deve conter ao menos uma letra maiúscula, um número e um caractere especial.");
    }
}
