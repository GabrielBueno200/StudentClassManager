using MediatR;
using StudentClassManager.Application.ViewModels;

namespace StudentClassManager.Application.Features.Classes.Commands.CreateClass;

public class CreateClassCommand : IRequest<ClassViewModel>
{
    public string? ClassName { get; set; }
    public int Year { get; set; }
}
