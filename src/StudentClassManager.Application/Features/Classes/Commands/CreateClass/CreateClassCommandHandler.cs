using AutoMapper;
using MediatR;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Classes.Commands.CreateClass;

public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand,
    ClassViewModel>
{
    private readonly IMapper _mapper;
    private readonly IClassRepository _repository;

    public CreateClassCommandHandler(IMapper mapper, IClassRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }


    public async Task<ClassViewModel> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        var validation = await new CreateClassCommandValidator().ValidateAsync(request);
        if (!validation.IsValid) throw new Exception("invalid");

        var classAlreadyExists = (await _repository.GetClassByNameAsync(request.ClassName!)) != null;
        if (classAlreadyExists) throw new Exception("invalid");

        var classToCreate = _mapper.Map<Domain.Models.Class>(request);

        var createdClass = await _repository.CreateAsync(classToCreate);

        var mappedClass = _mapper.Map<ClassViewModel>(createdClass);

        return mappedClass;
    }
}
