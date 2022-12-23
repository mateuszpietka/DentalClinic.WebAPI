using DentalClinic.VisitSchedule.Application.DTO;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries;
public record GetFreeDatesQuery(FreeDatesFilterDto FreeDatesFilter) : IRequest<FreeDatesDto>;
