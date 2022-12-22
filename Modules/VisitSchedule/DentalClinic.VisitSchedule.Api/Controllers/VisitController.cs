using DentalClinic.VisitSchedule.Application.Command;
using DentalClinic.VisitSchedule.Application.DTO;
using MediatR;
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
}