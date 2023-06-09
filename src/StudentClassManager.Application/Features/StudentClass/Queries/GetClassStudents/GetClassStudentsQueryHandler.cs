
using AutoMapper;
using MediatR;
using StudentClassManager.Application.Exceptions;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.StudentClass.Queries.GetClassStudents;

public class GetClassStudentsQueryHandler : IRequestHandler<GetClassStudentsQuery,
    IList<StudentViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IStudentClassRepository _repository;
    private readonly IClassRepository _classRepository;

    public GetClassStudentsQueryHandler(IMapper mapper, IStudentClassRepository repository, IClassRepository classRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _classRepository = classRepository;
    }

    public async Task<IList<StudentViewModel>> Handle(GetClassStudentsQuery request, CancellationToken cancellationToken)
    {
        // Validation
        var classExists = (await _classRepository.GetClassByIdAsync(request.ClassId)) != null;

        if (!classExists)
            throw new NotFoundException($"Não foi encontrada uma turma com o id {request.ClassId}");

        // Result
        var student = await _repository.GetClassStudentsAsync(request.ClassId);

        var mappedStudents = _mapper.Map<IList<StudentViewModel>>(student);

        return mappedStudents;
    }
}