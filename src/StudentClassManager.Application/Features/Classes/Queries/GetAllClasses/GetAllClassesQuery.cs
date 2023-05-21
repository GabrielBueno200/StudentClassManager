using MediatR;
using StudentClassManager.Application.ViewModels;

namespace StudentClassManager.Application.Features.Classes.Queries.GetAllClasses;

public record GetAllClassesQuery : IRequest<IList<ClassViewModel>>;