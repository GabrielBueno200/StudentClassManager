using AutoMapper;
using MediatR;
using StudentClassManager.Application.Exceptions;
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
        // Validation
        var studentExists = (await _repository.GetStudentByIdAsync(request.Id)) != null;

        if (!studentExists)
            throw new NotFoundException($"Não foi encontrada aluno com o id {request.Id}");

        // Result
        await _repository.InactivateStudentAsync(request.Id);

        return Unit.Value;
    }
}
