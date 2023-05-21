using AutoMapper;
using MediatR;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Student.Commands.InactivateStudent;

public class InactivateStudentCommandHandler : IRequestHandler<InactivateStudentCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _repository;

    public InactivateStudentCommandHandler(IMapper mapper, IStudentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(InactivateStudentCommand request, CancellationToken cancellationToken)
    {
        await _repository.InactivateStudentAsync(request.Id);

        return Unit.Value;
    }
}
