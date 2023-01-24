using DentalClinic.Users.Application.Command;
using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Application.Queries;
using DentalClinic.Users.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Users.Api.Controllers;

[Route("api/employee")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Administrator")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
    {
        var employees = await _mediator.Send(new GetEmployeesQuery());

        return Ok(employees);
    }

    [HttpGet("doctor")]
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctorList()
    {
        var doctors = await _mediator.Send(new GetDoctorsQuery());

        return Ok(doctors);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPost]
    public async Task<ActionResult> AddEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
    {
        var id = await _mediator.Send(new CreateEmpolyeeCommand(createEmployeeDto));

        return Created("", id);
    }

    [Authorize(Roles = "Administrator")]
    [HttpPut]
    public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        await _mediator.Send(new UpdateEmployeeCommand(updateEmployeeDto));

        return Ok();
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee([FromRoute] long id)
    {
        await _mediator.Send(new DeleteEmployeeCommand(id));

        return NoContent();
    }
}
