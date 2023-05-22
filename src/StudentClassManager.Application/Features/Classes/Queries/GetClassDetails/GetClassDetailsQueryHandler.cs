using AutoMapper;
using MediatR;
using StudentClassManager.Application.Exceptions;
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
        var existingClass = await _repository.GetClassByIdAsync(request.Id);

        if (existingClass == null)
            throw new NotFoundException($"Não foi encontrada uma turma com o id {request.Id}");

        var mappedClass = _mapper.Map<ClassViewModel>(existingClass);

        return mappedClass;
    }
}
