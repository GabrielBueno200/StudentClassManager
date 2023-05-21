using MediatR;

namespace StudentClassManager.Application.Features.Classes.Commands.InactivateClass;

public record InactivateClassCommand(int Id) : IRequest<Unit>;