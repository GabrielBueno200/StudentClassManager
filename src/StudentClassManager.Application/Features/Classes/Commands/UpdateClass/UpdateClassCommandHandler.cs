using AutoMapper;
using MediatR;
using StudentClassManager.Domain.Interfaces.Repositories;

namespace StudentClassManager.Application.Features.Classes.Commands.UpdateClass;

public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IClassRepository _repository;

    public UpdateClassCommandHandler(IMapper mapper, IClassRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }


    public async Task<Unit> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
    {
        var validation = await new UpdateClassCommandValidator()
                .ValidateAsync(request);

        if (!validation.IsValid) throw new Exception("invalid");
        
        var classAlreadyExists = (await _repository.GetClassByNameAsync(request.ClassName!)) != null;
        if (classAlreadyExists) throw new Exception("invalid");

        var classToUpdate = _mapper.Map<Domain.Models.Class>(request);

        await _repository.UpdateClassAsync(classToUpdate);

        return Unit.Value;
    }
}
