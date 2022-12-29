using DentalClinic.VisitSchedule.Core.Services;

namespace DentalClinic.VisitSchedule.Application.Services;
internal class WorkHoursService : IWorkHoursService
{
    private static readonly DayOfWeek[] s_workWeek = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
    private static readonly int s_workHourFrom = 8;
    private static readonly int s_workHourTo = 18;

    public WorkHoursService()
    {

    }

    public int WorkHourFrom => s_workHourFrom;
    public int WorkHourTo => s_workHourTo;

    public IEnumerable<DateTime> GetWorkHours(DateTime startDate, DateTime endDate)
    {
        for (DateTime i = startDate; i <= endDate;)
        {
            if (IncludeInWorkHoursRange(i))
                yield return i;

            i = i.AddHours(1);
        }
    }

    private bool IncludeInWorkHoursRange(DateTime dateTime)
    {
        return s_workWeek.Any(x => x == dateTime.DayOfWeek)
            && dateTime.Hour >= s_workHourFrom
            && dateTime.Hour < s_workHourTo;
    }
}
