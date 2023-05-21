using AutoMapper;
using MediatR;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Classes.Queries.GetClassDetails;

public class GetClassDetailsQueryHandler : IRequestHandler<GetClassDetailsQuery,
    ClassViewModel>
{
    private readonly IMapper _mapper;
    private readonly IClassRepository _repository;

    public GetClassDetailsQueryHandler(IMapper mapper, IClassRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ClassViewModel> Handle(GetClassDetailsQuery request, CancellationToken cancellationToken)
    {
        var student = await _repository.GetClassByIdAsync(request.Id);

        var mappedClass = _mapper.Map<ClassViewModel>(student);

        return mappedClass;
    }
}
