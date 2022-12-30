using DentalClinic.MedicalRecords.Application.PatientCars.Command;
using DentalClinic.MedicalRecords.Application.PatientCars.DTO;
using DentalClinic.MedicalRecords.Application.PatientCars.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.MedicalRecords.Api.Controllers;
[Route("api/patientCard")]
[ApiController]
public class PatientCardController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientCardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("annotation")]
    [Authorize(Roles = "Doctor")]
    public async Task<IActionResult> AddPatientCardAnnotation([FromBody] AddPatientCardAnnotationDto addPatientCardAnnotationDto)
    {
        await _mediator.Send(new AddPatientCardAnnotationCommand(addPatientCardAnnotationDto));

        return Ok();
    }

    [HttpGet("{patientId}")]
    [Authorize(Roles = "Patient")]
    public async Task<ActionResult<PatientCardDto>> GetPatientCard([FromRoute] long patientId)
    {
        var patientCard = await _mediator.Send(new GetPatientCardQuery(patientId));

        return Ok(patientCard);
    }
}