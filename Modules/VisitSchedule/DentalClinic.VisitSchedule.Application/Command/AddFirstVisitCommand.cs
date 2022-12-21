using DentalClinic.VisitSchedule.Application.DTO;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Command;

public record AddFirstVisitCommand(CreateFirstVisitDto FirstVisitDto): IRequest<int>;
