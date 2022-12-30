using DentalClinic.VisitSchedule.Application.DTO;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries;
public record GetVisitDetilsQuery(long VisitId) : IRequest<VisitDetailsDto>;
