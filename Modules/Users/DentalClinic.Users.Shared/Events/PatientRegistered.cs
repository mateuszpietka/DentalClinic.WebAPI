using MediatR;

namespace DentalClinic.Users.Shared.Events;

public record PatientRegistered(long PatientId) : INotification;
