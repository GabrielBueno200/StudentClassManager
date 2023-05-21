using MediatR;

namespace StudentClassManager.Application.Features.Student.Commands.ActivateStudent;

public class ActivateStudentCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public bool Activate { get; set; }
}
