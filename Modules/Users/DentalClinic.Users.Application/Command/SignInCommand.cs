using DentalClinic.Users.Application.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Command;

public record SignInCommand(SignInDto SignInDto) : IRequest<AuthDto>;