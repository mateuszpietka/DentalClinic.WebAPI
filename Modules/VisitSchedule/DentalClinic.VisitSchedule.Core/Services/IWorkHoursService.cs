namespace DentalClinic.VisitSchedule.Core.Services;
public interface IWorkHoursService
{
    int WorkHourFrom { get; }
    int WorkHourTo { get; }
    IEnumerable<DateTime> GetWorkHours (DateTime startDate, DateTime endDate);
}
