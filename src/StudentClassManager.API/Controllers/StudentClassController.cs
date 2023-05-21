using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Application.Features.StudentClass.Queries.GetClassStudents;
using StudentClassManager.Application.Features.StudentClass.Commands.RemoveStudentFromClass;
using StudentClassManager.Application.Features.StudentClass.Commands.AssociateStudentWithClass;

namespace StudentClassManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentClassController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentClassController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{classId}")]
    public async Task<ActionResult<IList<StudentViewModel>>> GetClassStudentsAsync([FromRoute] int classId)
    {
        var classStudents = await _mediator.Send(new GetClassStudentsQuery(classId));
        return Ok(classStudents);
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveStudentFromClassAsync([FromBody] RemoveStudentFromClassCommand studentClass)
    {
        await _mediator.Send(studentClass);
        return Ok();
    }

    [HttpPost("associate")]
    public async Task<IActionResult> AssociateStudentWithClassAsync([FromBody] AssociateStudentWithClassCommand studentClass)
    {
        await _mediator.Send(studentClass);
        return Ok();
    }
}
