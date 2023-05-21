
using MediatR;

namespace StudentClassManager.Application.Features.Classes.Commands.UpdateClass;

public class UpdateClassCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? ClassName { get; set; }
    public int Year { get; set; }
}