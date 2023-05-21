using AutoMapper;
using MediatR;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Student.Commands.ActivateStudent;

public class ActivateStudentCommandHandler : IRequestHandler<ActivateStudentCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _repository;

    public ActivateStudentCommandHandler(IMapper mapper, IStudentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(ActivateStudentCommand request, CancellationToken cancellationToken)
    {
        await _repository.ActivateStudentAsync(request.Id, request.Activate);

        return Unit.Value;
    }
}
