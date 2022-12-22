using DentalClinic.VisitSchedule.Application.DTO;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command;

public record AddVisitCommand(CreateVisitDto VisitDto): IRequest<long>;
