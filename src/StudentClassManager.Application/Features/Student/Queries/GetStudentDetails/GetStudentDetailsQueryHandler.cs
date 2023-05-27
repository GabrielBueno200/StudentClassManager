using AutoMapper;
using MediatR;
using StudentClassManager.Application.Exceptions;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Student.Queries.GetStudentDetails;

public class GetStudentDetailsQueryHandler : IRequestHandler<GetStudentDetailsQuery,
    StudentViewModel>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _repository;

    public GetStudentDetailsQueryHandler(IMapper mapper, IStudentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<StudentViewModel> Handle(GetStudentDetailsQuery request, CancellationToken cancellationToken)
    {
        var student = await _repository.GetStudentByIdAsync(request.Id);

        // Validation
        if (student == null)
            throw new NotFoundException($"Não foi encontrado um aluno com o id {request.Id}");

        // Result
        var mappedStudent = _mapper.Map<StudentViewModel>(student);

        return mappedStudent;
    }
}
