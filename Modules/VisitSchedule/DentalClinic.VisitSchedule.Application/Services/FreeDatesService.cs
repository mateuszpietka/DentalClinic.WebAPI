using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Services;

namespace DentalClinic.VisitSchedule.Application.Services;
internal class FreeDatesService : IFreeDatesService
{
    private readonly IWorkHoursService _workHoursService;
    private readonly IVisitScheduleService _visitScheduleService;

    public FreeDatesService(IWorkHoursService workHoursService, IVisitScheduleService visitScheduleService)
    {
        _workHoursService = workHoursService;
        _visitScheduleService = visitScheduleService;
    }

    public async Task<IEnumerable<DateTime>> GetFreeDates(long doctorId, VisitType visitType, DateTime dateFrom, DateTime dateTo)
    {
        var visitsToSchedule = (await _visitScheduleService.GetDoctorVisitSchedule(doctorId, dateFrom, dateTo)).OrderBy(x => x.DateFrom).ToArray();
        var workHours = _workHoursService.GetWorkHours(dateFrom, dateTo);
        var freeDates = new List<DateTime>();

        foreach (var date in workHours)
        {
            if (visitsToSchedule.Any(x => x.DateFrom == date))
                continue;

            if (visitsToSchedule.Any(x => date > x.DateFrom && date < x.DateTo))
                continue;

            if (visitsToSchedule.Any(x => date.AddHours(visitType.Hours) > x.DateFrom && date.AddHours(visitType.Hours) < x.DateTo))
                continue;

            if (date.AddHours(visitType.Hours).Hour > _workHoursService.WorkHourTo)
                continue;

            if (visitsToSchedule.Any(x => x.DateFrom >= date && x.DateFrom < date.AddHours(visitType.Hours)))
                continue;

            freeDates.Add(date);
        }

        return freeDates;
    }
}