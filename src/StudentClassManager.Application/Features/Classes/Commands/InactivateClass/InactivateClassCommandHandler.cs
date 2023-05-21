using AutoMapper;
using MediatR;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Classes.Commands.InactivateClass;

public class InactivateClassCommandHandler : IRequestHandler<InactivateClassCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IClassRepository _repository;

    public InactivateClassCommandHandler(IMapper mapper, IClassRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(InactivateClassCommand request, CancellationToken cancellationToken)
    {
        await _repository.InactivateClassAsync(request.Id);

        return Unit.Value;
    }
}