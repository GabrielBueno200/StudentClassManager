using MediatR;
using StudentClassManager.Application.ViewModels;

namespace StudentClassManager.Application.Features.StudentClass.Queries.GetStudentsToAssociate;

public record GetStudentsToAssociateQuery(int ClassId) : IRequest<IList<StudentViewModel>>;
