using FluentValidation;

namespace StudentClassManager.Application.Features.Student.Commands.CreateStudent;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(p => p.Name).
            NotNull()
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(255).WithMessage("Nome pode conter no máximo 255 caracteres");
            
        RuleFor(p => p.UserName)
            .NotNull()
            .NotEmpty().WithMessage("Usuário é obrigatório")
            .MaximumLength(45).WithMessage("Usuário pode conter no máximo 45 caracteres");
        
        RuleFor(p => p.Password)
            .MinimumLength(8).WithMessage("Senha requer ao menos caracteres")
            .Matches(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$")
            .WithMessage("Senha deve conter ao menos uma letra maiúscula, um número e um caractere especial.");
    }
}
