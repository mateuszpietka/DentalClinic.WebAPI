using DentalClinic.VisitSchedule.Application.DTO;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries;
public record GetReceptionistVisitScheduleQuery(ReceptionistVisitScheduleFilterDto VisitScheduleFilter) : IRequest<VisitScheduleDto>;
