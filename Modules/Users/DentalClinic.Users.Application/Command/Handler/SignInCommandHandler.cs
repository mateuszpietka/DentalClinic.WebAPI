using DentalClinic.Users.Application.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Command.Handler;

internal class SignInCommandHandler : IRequestHandler<SignInCommand, AuthDto>
{
    public SignInCommandHandler()
    {

    }

    public Task<AuthDto> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
