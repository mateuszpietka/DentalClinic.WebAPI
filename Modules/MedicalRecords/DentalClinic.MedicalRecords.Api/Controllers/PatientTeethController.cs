using DentalClinic.MedicalRecords.Application.Toothing.Command;
using DentalClinic.MedicalRecords.Application.Toothing.DTO;
using DentalClinic.MedicalRecords.Application.Toothing.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.MedicalRecords.Api.Controllers;
[Route("api/patientTeeth")]
[ApiController]
public class PatientTeethController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientTeethController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("markSick")]
    [Authorize(Roles = "Doctor")]
    public async Task<IActionResult> MarkPatientSickTeeth([FromBody] MarkTeethDto markTeethDto)
    {
        await _mediator.Send(new MarkSickTeethCommand(markTeethDto));

        return Ok();
    }

    [HttpPost("markHealthy")]
    [Authorize(Roles = "Doctor")]
    public async Task<IActionResult> MarkPatientHealthyTeeth([FromBody] MarkTeethDto markTeethDto)
    {
        await _mediator.Send(new MarkHealthyTeethCommand(markTeethDto));

        return Ok();
    }

    [HttpGet("{patientId}")]
    [Authorize(Roles = "Patient, Doctor")]
    public async Task<ActionResult<PatientTeethConditionDto>> GetPatientTeethCondition([FromRoute] long patientId)
    {
        var patientTeethCondition = await _mediator.Send(new GetPatientTeethConditionQuery(patientId));

        return Ok(patientTeethCondition);
    }
}
