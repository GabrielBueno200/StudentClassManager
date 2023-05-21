using AutoMapper;
using MediatR;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.StudentClass.Commands.AssociateStudentWithClass;

public class AssociateStudentWithClassCommandHandler : IRequestHandler<AssociateStudentWithClassCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IStudentClassRepository _repository;

    public AssociateStudentWithClassCommandHandler(IMapper mapper, IStudentClassRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(AssociateStudentWithClassCommand request, CancellationToken cancellationToken)
    {
        await _repository.AssociateStudentWithClassAsync(request.ClassId, request.StudentId);

        return Unit.Value;
    }
}