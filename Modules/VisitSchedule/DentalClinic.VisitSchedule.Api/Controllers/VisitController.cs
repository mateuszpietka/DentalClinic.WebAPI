﻿using DentalClinic.VisitSchedule.Application.Command;
using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.VisitSchedule.Api.Controllers;
[Route("api/visit")]
[ApiController]
public class VisitController : ControllerBase
{
    private readonly IMediator _mediator;

    public VisitController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("firstVisit")]
    public async Task<ActionResult> AddFirstVisit([FromBody] CreateFirstVisitDto createFirstVisitDto)
    {
        await _mediator.Send(new AddFirstVisitCommand(createFirstVisitDto));

        return Ok();
    }

    [HttpPost]
    [Authorize(Roles = "Patient, Receptionist")]
    public async Task<ActionResult> AddVisit([FromBody] CreateVisitDto createVisitDto)
    {
        await _mediator.Send(new AddVisitCommand(createVisitDto));

        return Ok();
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Doctor")]
    public async Task<ActionResult<VisitDetailsDto>> GetVisitDetails([FromRoute] long id)
    {
        var visitDetails = await _mediator.Send(new GetVisitDetilsQuery(id));

        return Ok(visitDetails);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Patient, Receptionist, Doctor")]
    public async Task<ActionResult> CancellationVisit([FromRoute] long id)
    {
        await _mediator.Send(new CancellationVisitCommand(id));

        return NoContent();
    }
}