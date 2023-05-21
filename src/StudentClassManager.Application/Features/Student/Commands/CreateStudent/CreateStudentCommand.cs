using MediatR;
using StudentClassManager.Application.ViewModels;

namespace StudentClassManager.Application.Features.Student.Commands.CreateStudent;

public class CreateStudentCommand : IRequest<StudentViewModel>
{
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}
