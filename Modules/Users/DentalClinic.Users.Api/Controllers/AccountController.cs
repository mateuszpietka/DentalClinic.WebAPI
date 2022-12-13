using DentalClinic.Users.Application.Command;
using DentalClinic.Users.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.Users.Api.Controllers;

[ApiController]
internal class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<AuthDto>> SignIn([FromBody] SignInDto signInDto)
    {
        var result = await _mediator.Send(new SignInCommand(signInDto));

        return Ok(result);
    }
}
