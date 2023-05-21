using MediatR;
using StudentClassManager.Application.ViewModels;

namespace StudentClassManager.Application.Features.StudentClass.Queries.GetClassStudents;

public record GetClassStudentsQuery(int ClassId) : IRequest<IList<StudentViewModel>>;