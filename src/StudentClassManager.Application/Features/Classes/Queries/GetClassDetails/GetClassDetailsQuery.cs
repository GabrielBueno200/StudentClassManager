using MediatR;
using StudentClassManager.Application.ViewModels;

namespace StudentClassManager.Application.Features.Classes.Queries.GetClassDetails;

public record GetClassDetailsQuery(int Id) : IRequest<ClassViewModel>;