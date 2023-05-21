using AutoMapper;
using MediatR;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;

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
        var validation = await new CreateStudentCommandValidator()
                .ValidateAsync(request);

        if (!validation.IsValid) throw new Exception("invalid");

        var studentToCreate = _mapper.Map<Domain.Models.Student>(request);

        var createdStudent = await _repository.CreateAsync(studentToCreate);

        var mappedStudent = _mapper.Map<StudentViewModel>(createdStudent);

        return mappedStudent;
    }
}
