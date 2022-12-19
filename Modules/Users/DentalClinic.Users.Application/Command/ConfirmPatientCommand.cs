using MediatR;

namespace DentalClinic.Users.Application.Command;

public record ConfirmPatientCommand(long PatientId) : IRequest;
