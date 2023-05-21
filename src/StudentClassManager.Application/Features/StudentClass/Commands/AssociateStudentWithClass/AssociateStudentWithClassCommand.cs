using MediatR;

namespace StudentClassManager.Application.Features.StudentClass.Commands.AssociateStudentWithClass;

public record AssociateStudentWithClassCommand(int ClassId, int StudentId) : IRequest<Unit>;