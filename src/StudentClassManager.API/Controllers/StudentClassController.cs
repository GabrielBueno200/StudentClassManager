using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Application.Features.StudentClass.Queries.GetClassStudents;
using StudentClassManager.Application.Features.StudentClass.Commands.RemoveStudentFromClass;
using StudentClassManager.Application.Features.StudentClass.Commands.AssociateStudentWithClass;
using StudentClassManager.Application.Features.StudentClass.Queries.GetStudentsToAssociate;

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

    [HttpDelete("{classId}/{studentId}")]
    public async Task<IActionResult> RemoveStudentFromClassAsync([FromRoute] int classId, [FromRoute] int studentId)
    {
        await _mediator.Send(new RemoveStudentFromClassCommand(classId, studentId));
        return Ok();
    }

    [HttpPost("associate")]
    public async Task<IActionResult> AssociateStudentWithClassAsync([FromBody] AssociateStudentWithClassCommand studentClass)
    {
        await _mediator.Send(studentClass);
        return Ok();
    }

    [HttpGet("studentsToAssociate/{classId}")]
    public async Task<IActionResult> GetStudentsToAssociateAsync([FromRoute] int classId)
    {
        var studentsToAssociate = await _mediator.Send(new GetStudentsToAssociateQuery(classId));
        return Ok(studentsToAssociate);
    }
}
