using MediatR;

namespace StudentClassManager.Application.Features.Student.Commands.UpdateStudent;

public class UpdateStudentCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}
