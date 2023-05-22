using AutoMapper;
using MediatR;
using StudentClassManager.Application.Exceptions;
using StudentClassManager.Application.Extensions;
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
        validation.VerifyErrorsAndThrow();

        if (!validation.IsValid) 
            throw new BadRequestException( "");
        
        var classAlreadyExists = (await _repository.GetClassByNameAsync(request.ClassName!)) != null;
        if (classAlreadyExists) 
            throw new BadRequestException("Já existe uma turma cadastrada com o nome informado");

        var classToUpdate = _mapper.Map<Domain.Models.Class>(request);

        await _repository.UpdateClassAsync(classToUpdate);

        return Unit.Value;
    }
}
