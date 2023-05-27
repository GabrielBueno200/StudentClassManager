using AutoMapper;
using MediatR;
using StudentClassManager.Application.Exceptions;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.StudentClass.Commands.AssociateStudentWithClass;

public class AssociateStudentWithClassCommandHandler : IRequestHandler<AssociateStudentWithClassCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IStudentClassRepository _repository;
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;

    public AssociateStudentWithClassCommandHandler(IMapper mapper, IStudentClassRepository repository, IStudentRepository studentRepository, IClassRepository classRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _studentRepository = studentRepository;
        _classRepository = classRepository;
    }

    public async Task<Unit> Handle(AssociateStudentWithClassCommand request, CancellationToken cancellationToken)
    {
        // Validation
        var studentExists = (await _studentRepository.GetStudentByIdAsync(request.StudentId)) != null;
        var classExists = (await _classRepository.GetClassByIdAsync(request.ClassId)) != null;
        var studentAlreadyInClass = await _repository.VerifyIfStudentIsInClass(request.ClassId, request.StudentId);

        if (!studentExists)
            throw new NotFoundException($"Não foi encontrado um aluno turma com o id {request.StudentId}");

        if (!classExists)
            throw new NotFoundException($"Não foi encontrada uma turma com o id {request.ClassId}");

        if (studentAlreadyInClass)
            throw new BadRequestException($"O estudante informado já está associado a essa turma");

        // Result
        await _repository.AssociateStudentWithClassAsync(request.ClassId, request.StudentId);

        return Unit.Value;
    }
}