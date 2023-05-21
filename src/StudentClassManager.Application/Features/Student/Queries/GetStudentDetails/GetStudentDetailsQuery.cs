using MediatR;
using StudentClassManager.Application.ViewModels;

namespace StudentClassManager.Application.Features.Student.Queries.GetStudentDetails;

public record GetStudentDetailsQuery(int Id) : IRequest<StudentViewModel>;
