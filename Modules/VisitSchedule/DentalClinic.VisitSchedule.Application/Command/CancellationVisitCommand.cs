using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command;

public record CancellationVisitCommand(long VisitId): IRequest;