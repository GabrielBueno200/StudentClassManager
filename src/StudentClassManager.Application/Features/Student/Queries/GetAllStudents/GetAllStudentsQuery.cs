using MediatR;
using StudentClassManager.Application.ViewModels;

namespace StudentClassManager.Application.Features.Student.Queries.GetAllStudents;

public record GetAllStudentsQuery : IRequest<IList<StudentViewModel>>;
