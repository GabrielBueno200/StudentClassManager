using AutoMapper;
using MediatR;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Student.Queries.GetAllStudents;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery,
    IList<StudentViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _repository;

    public GetAllStudentsQueryHandler(IMapper mapper, IStudentRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IList<StudentViewModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await _repository.GetAllStudentsAsync();

        var mappedStudents = _mapper.Map<IList<StudentViewModel>>(students);

        return mappedStudents;
    }
}
