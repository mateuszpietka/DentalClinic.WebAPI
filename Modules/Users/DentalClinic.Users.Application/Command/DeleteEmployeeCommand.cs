using MediatR;

namespace DentalClinic.Users.Application.Command;
public record DeleteEmployeeCommand(long EmployeeId) : IRequest;