using AutoMapper;
using MediatR;
using StudentClassManager.Application.Extensions;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;
using StudentClassManager.Infrastructure.Security;

namespace StudentClassManager.Application.Features.Student.Commands.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand,
    StudentViewModel>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _repository;

    public CreateStudentCommandHandler(IMapper mapper, IStudentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }


    public async Task<StudentViewModel> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        // Validation
        var validation = await new CreateStudentCommandValidator()
                .ValidateAsync(request);
        validation.VerifyErrorsAndThrow();

        // Mapping
        var studentToCreate = _mapper.Map<Domain.Models.Student>(request);

        // Password Encrypt
        studentToCreate.Password = PasswordEncryption.EncryptPassword(studentToCreate.Password!);

        // Result
        var createdStudent = await _repository.CreateAsync(studentToCreate);

        var mappedStudent = _mapper.Map<StudentViewModel>(createdStudent);

        return mappedStudent;
    }
}
