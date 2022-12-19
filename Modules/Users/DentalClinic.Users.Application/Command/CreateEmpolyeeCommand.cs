using DentalClinic.Users.Application.DTO;
using MediatR;

namespace DentalClinic.Users.Application.Command;
public record CreateEmpolyeeCommand(CreateEmployeeDto CreateEmployeeDto) : IRequest<long>;