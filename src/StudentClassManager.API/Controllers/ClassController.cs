using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Application.Features.Classes.Commands.CreateClass;
using StudentClassManager.Application.Features.Classes.Commands.UpdateClass;
using StudentClassManager.Application.Features.Classes.Queries.GetClassDetails;
using StudentClassManager.Application.Features.Classes.Queries.GetAllClasses;
using StudentClassManager.Application.Features.Classes.Commands.InactivateClass;

namespace StudentClassManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<ClassViewModel>> CreateAsync([FromBody] CreateClassCommand classToCreate)
    {
        var createdClass = await _mediator.Send(classToCreate);
        return Ok(createdClass);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateClassCommand classToUpdate)
    {
        var updatedClass = await _mediator.Send(classToUpdate);
        return Ok(updatedClass);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClassViewModel>> GetByIdAsync([FromRoute] int id)
    {
        var existingClass = await _mediator.Send(new GetClassDetailsQuery(id));
        return Ok(existingClass);
    }

    [HttpGet]
    public async Task<ActionResult<ClassViewModel>> GetAllAsync()
    {
        var classes = await _mediator.Send(new GetAllClassesQuery());
        return Ok(classes);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> InactivateAsync([FromRoute] int id)
    {
        await _mediator.Send(new InactivateClassCommand(id));
        return Ok();
    }
}
