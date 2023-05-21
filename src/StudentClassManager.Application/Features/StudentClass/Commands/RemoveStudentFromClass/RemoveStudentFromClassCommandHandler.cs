using AutoMapper;
using MediatR;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.StudentClass.Commands.RemoveStudentFromClass;

public class RemoveStudentFromClassCommandHandler : IRequestHandler<RemoveStudentFromClassCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IStudentClassRepository _repository;

    public RemoveStudentFromClassCommandHandler(IMapper mapper, IStudentClassRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(RemoveStudentFromClassCommand request, CancellationToken cancellationToken)
    {
        await _repository.RemoveStudentFromClassAsync(request.ClassId, request.StudentId);

        return Unit.Value;
    }
}