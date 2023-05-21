using AutoMapper;
using MediatR;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Student.Commands.UpdateStudent;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _repository;

    public UpdateStudentCommandHandler(IMapper mapper, IStudentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var studentToUpdate = _mapper.Map<Domain.Models.Student>(request);

        await _repository.UpdateStudentAsync(studentToUpdate);

        return Unit.Value;
    }
}
