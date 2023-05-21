using MediatR;

namespace StudentClassManager.Application.Features.Student.Commands.InactivateStudent;

public record InactivateStudentCommand(int Id) : IRequest<Unit>;
