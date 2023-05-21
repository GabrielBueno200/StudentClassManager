using MediatR;

namespace StudentClassManager.Application.Features.StudentClass.Commands.RemoveStudentFromClass;

public record RemoveStudentFromClassCommand(int ClassId, int StudentId) : IRequest<Unit>;
