using DentalClinic.Users.Application.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Command;

public record RegisterPatientCommand(RegisterPatientDto RegisterPatientDto) : IRequest<long>;
