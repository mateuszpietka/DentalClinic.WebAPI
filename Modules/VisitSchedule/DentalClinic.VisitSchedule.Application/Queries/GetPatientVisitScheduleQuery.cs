using DentalClinic.VisitSchedule.Application.DTO;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries;
public record GetPatientVisitScheduleQuery(PatientVisitScheduleFilterDto VisitScheduleFilter) : IRequest<VisitScheduleDto>;
