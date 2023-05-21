
using AutoMapper;
using MediatR;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.StudentClass.Queries.GetClassStudents;

public class GetClassStudentsQueryHandler : IRequestHandler<GetClassStudentsQuery,
    IList<StudentViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IStudentClassRepository _repository;

    public GetClassStudentsQueryHandler(IMapper mapper, IStudentClassRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IList<StudentViewModel>> Handle(GetClassStudentsQuery request, CancellationToken cancellationToken)
    {
        var student = await _repository.GetClassStudentsAsync(request.ClassId);

        var mappedStudents = _mapper.Map<IList<StudentViewModel>>(student);

        return mappedStudents;
    }
}