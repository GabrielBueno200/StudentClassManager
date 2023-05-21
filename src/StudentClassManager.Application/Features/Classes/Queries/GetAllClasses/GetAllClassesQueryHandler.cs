
using AutoMapper;
using MediatR;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Classes.Queries.GetAllClasses;

public class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery,
    IList<ClassViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IClassRepository _repository;

    public GetAllClassesQueryHandler(IMapper mapper, IClassRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IList<ClassViewModel>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
    {
        var classes = await _repository.GetAllClassesAsync();

        var mappedClasses = _mapper.Map<IList<ClassViewModel>>(classes);

        return mappedClasses;
    }
}
