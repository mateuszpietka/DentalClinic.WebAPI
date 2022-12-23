using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.VisitSchedule.Api.Controllers;

[Route("api/schedule")]
[ApiController]
public class ScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public ScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("patient")]
    [Authorize(Roles = "Patient")]
    public async Task<ActionResult<VisitScheduleDto>> GetVisitSchedule([FromBody] PatientVisitScheduleFilterDto visitScheduleFilterDto)
    {
        var visitSchedule = await _mediator.Send(new GetPatientVisitScheduleQuery(visitScheduleFilterDto));

        return Ok(visitSchedule);
    }

    [HttpGet("doctor")]
    [Authorize(Roles = "Doctor")]
    public async Task<ActionResult<VisitScheduleDto>> GetVisitSchedule([FromBody] DoctorVisitScheduleFilterDto visitScheduleFilterDto)
    {
        var visitSchedule = await _mediator.Send(new GetDoctorVisitScheduleQuery(visitScheduleFilterDto));

        return Ok(visitSchedule);
    }

    [HttpGet("receptionist")]
    [Authorize(Roles = "Receptionist")]
    public async Task<ActionResult<VisitScheduleDto>> GetVisitSchedule([FromBody] ReceptionistVisitScheduleFilterDto visitScheduleFilterDto)
    {
        var visitSchedule = await _mediator.Send(new GetReceptionistVisitScheduleQuery(visitScheduleFilterDto));

        return Ok(visitSchedule);
    }

    [HttpGet("freeDates")]
    [Authorize(Roles = "Receptionist, Patient")]
    public async Task<ActionResult<FreeDatesDto>> GetFreeDates([FromBody] FreeDatesFilterDto freeDatesFilterDto)
    {
        var freeDatesDto = await _mediator.Send(new GetFreeDatesQuery(freeDatesFilterDto));

        return Ok(freeDatesDto);
    }
}