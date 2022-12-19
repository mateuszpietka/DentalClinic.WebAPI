using DentalClinic.Users.Application.Command;
using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Users.Api.Controllers;

[Route("api/patient")]
[ApiController]
[Authorize(Roles = "Receptionist")]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
    {
        var patients = await _mediator.Send(new GetPatientsQuery());

        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<PatientDetailsDto>>> GetPatient([FromRoute] long id)
    {
        var patient = await _mediator.Send(new GetPatientQuery(id));

        return Ok(patient);
    }

    [HttpPut("confirmation/{id}")]
    public async Task<ActionResult> ConfirmPatient([FromRoute] long id)
    {
        await _mediator.Send(new ConfirmPatientCommand(id));

        return Ok();
    }
}
