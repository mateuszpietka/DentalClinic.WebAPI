using DentalClinic.Users.Application.Command;
using DentalClinic.Users.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Users.Api.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("registerPatient")]
    public async Task<ActionResult> RegisterPatient([FromBody] RegisterPatientDto registerPatientDto)
    {
        var resultId = await _mediator.Send(new RegisterPatientCommand(registerPatientDto));

        return Created($"api/patient/{resultId}", resultId);
    }

    [HttpPost("signIn")]
    public async Task<ActionResult<TokenDto>> SignIn([FromBody] SignInDto signInDto)
    {
        var authDto = await _mediator.Send(new SignInCommand(signInDto));

        return Ok(authDto);
    }
}