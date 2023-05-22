using AutoMapper;
using MediatR;
using StudentClassManager.Application.Exceptions;
using StudentClassManager.Domain.Interfaces.Repositories;
using StudentClassManager.Domain.Models;

namespace StudentClassManager.Application.Features.StudentClass.Commands.RemoveStudentFromClass;

public class RemoveStudentFromClassCommandHandler : IRequestHandler<RemoveStudentFromClassCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IStudentClassRepository _repository;
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;

    public RemoveStudentFromClassCommandHandler(IMapper mapper, IStudentClassRepository repository, IStudentRepository studentRepository, IClassRepository classRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _studentRepository = studentRepository;
        _classRepository = classRepository;
    }

    public async Task<Unit> Handle(RemoveStudentFromClassCommand request, CancellationToken cancellationToken)
    {
        // Validation
        var studentExists = (await _studentRepository.GetStudentByIdAsync(request.StudentId)) != null;
        var classExists = (await _classRepository.GetClassByIdAsync(request.ClassId)) != null;

        if (!studentExists)
            throw new NotFoundException($"Não foi encontrada um aluno com o id {request.StudentId}");

        if (!classExists)
            throw new NotFoundException($"Não foi encontrada uma turma com o id {request.StudentId}");

        // Result
        await _repository.RemoveStudentFromClassAsync(request.ClassId, request.StudentId);

        return Unit.Value;
    }
}