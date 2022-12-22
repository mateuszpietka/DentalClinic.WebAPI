using DentalClinic.VisitSchedule.Application.DTO;
using MediatR;

namespace DentalClinic.VisitSchedule.Application.Queries;
public record GetDoctorVisitScheduleQuery(DoctorVisitScheduleFilterDto VisitScheduleFilter) : IRequest<VisitScheduleDto>;
