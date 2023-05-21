using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentClassManager.Application.ViewModels;
using StudentClassManager.Application.Features.Student.Commands.CreateStudent;
using StudentClassManager.Application.Features.Student.Queries.GetStudentDetails;
using StudentClassManager.Application.Features.Student.Queries.GetAllStudents;
using StudentClassManager.Application.Features.Student.Commands.ActivateStudent;
using StudentClassManager.Application.Features.Student.Commands.UpdateStudent;

namespace StudentClassManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<StudentViewModel>> CreateAsync([FromBody] CreateStudentCommand student)
    {
        var createdStudent = await _mediator.Send(student);
        return Ok(createdStudent);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateStudentCommand student)
    {
        var updatedStudent = await _mediator.Send(student);
        return Ok(updatedStudent);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentViewModel>> GetByIdAsync([FromRoute] int id)
    {
        var student = await _mediator.Send(new GetStudentDetailsQuery(id));
        return Ok(student);
    }

    [HttpGet]
    public async Task<ActionResult<StudentViewModel>> GetAllAsync()
    {
        var students = await _mediator.Send(new GetAllStudentsQuery());
        return Ok(students);
    }

    [HttpPost("activate")]
    public async Task<IActionResult> ActivateAsync([FromBody] ActivateStudentCommand activate)
    {
        await _mediator.Send(activate);
        return Ok();
    }
}
