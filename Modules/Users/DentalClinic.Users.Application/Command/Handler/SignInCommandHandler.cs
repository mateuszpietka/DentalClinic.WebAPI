using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Core.Authentication;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Exceptions;
using DentalClinic.Users.Core.Repositories;
using DentalClinic.Users.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DentalClinic.Users.Application.Command.Handler;

internal class SignInCommandHandler : IRequestHandler<SignInCommand, TokenDto>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAuthenticationSettings _authenticationSettings;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public SignInCommandHandler(
        IAuthenticationService authenticationService,
        IAuthenticationSettings authenticationSettings,
        IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher)
    {
        _authenticationService = authenticationService;
        _authenticationSettings = authenticationSettings;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<TokenDto> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.SignInDto.Email);

        if (user == null)
            throw new InvalidEmailOrPasswordException();

        var passwordHash = _passwordHasher.HashPassword(user, request.SignInDto.Password);

        if (passwordHash != user.PasswordHash)
            throw new InvalidEmailOrPasswordException();

        var token = _authenticationService.GenerateToken(user);
        var expire = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDay);

        return new TokenDto(token, expire);
    }
}
