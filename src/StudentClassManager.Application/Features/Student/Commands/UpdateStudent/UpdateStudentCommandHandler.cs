using AutoMapper;
using MediatR;
using StudentClassManager.Application.Exceptions;
using StudentClassManager.Application.Extensions;
using StudentClassManager.Domain.Interfaces.Repositories;
using StudentClassManager.Infrastructure.Security;

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
        // Validation
        var validation = await new UpdateStudentCommandValidator()
                .ValidateAsync(request);
        validation.VerifyErrorsAndThrow();

        var studentExists = (await _repository.GetStudentByIdAsync(request.Id)) != null;

        if (!studentExists)
            throw new NotFoundException($"Não foi encontrada um aluno com o id {request.Id}");

        // Mapping
        var studentToUpdate = _mapper.Map<Domain.Models.Student>(request);

        // Password Encrypt
        studentToUpdate.Password = PasswordEncryption.EncryptPassword(studentToUpdate.Password!);

        // Result
        await _repository.UpdateStudentAsync(studentToUpdate);

        return Unit.Value;
    }
}
