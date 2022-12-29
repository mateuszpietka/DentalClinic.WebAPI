using DentalClinic.VisitSchedule.Application.Services;
using DentalClinic.VisitSchedule.Core.Services;
using Xunit;

namespace VisitSchedule.Tests.Unit.Services;
public class WorkHoursServiceTests
{
    private readonly IWorkHoursService _workHoursService;

    public WorkHoursServiceTests()
    {
        _workHoursService = new WorkHoursService();
    }

    [Fact]
    public void get_hours_for_one_day()
    {
        IEnumerable<DateTime> expected = new List<DateTime>()
        {
            new DateTime(2022, 12, 05, 08, 00, 00),
            new DateTime(2022, 12, 05, 09, 00, 00),
            new DateTime(2022, 12, 05, 10, 00, 00),
            new DateTime(2022, 12, 05, 11, 00, 00),
            new DateTime(2022, 12, 05, 12, 00, 00),
            new DateTime(2022, 12, 05, 13, 00, 00),
            new DateTime(2022, 12, 05, 14, 00, 00),
            new DateTime(2022, 12, 05, 15, 00, 00),
            new DateTime(2022, 12, 05, 16, 00, 00),
            new DateTime(2022, 12, 05, 17, 00, 00),
        };

        var result = _workHoursService.GetWorkHours(new DateTime(2022, 12, 05, 00, 00, 00), new DateTime(2022, 12, 5, 23, 59, 59));

        Assert.Equal(expected, result);
    }

    [Fact]
    public void get_hours_for_week()
    {
        var expected = GetExpectedValuesForWeek();

        var result = _workHoursService.GetWorkHours(new DateTime(2022, 12, 05, 00, 00, 00), new DateTime(2022, 12, 11, 23, 59, 59));

        Assert.Equal(expected, result);
    }

    private IEnumerable<DateTime> GetExpectedValuesForWeek()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new DateTime(2022, 12, 05 + i, 08, 00, 00);
            yield return new DateTime(2022, 12, 05 + i, 09, 00, 00);
            yield return new DateTime(2022, 12, 05 + i, 10, 00, 00);
            yield return new DateTime(2022, 12, 05 + i, 11, 00, 00);
            yield return new DateTime(2022, 12, 05 + i, 12, 00, 00);
            yield return new DateTime(2022, 12, 05 + i, 13, 00, 00);
            yield return new DateTime(2022, 12, 05 + i, 14, 00, 00);
            yield return new DateTime(2022, 12, 05 + i, 15, 00, 00);
            yield return new DateTime(2022, 12, 05 + i, 16, 00, 00);
            yield return new DateTime(2022, 12, 05 + i, 17, 00, 00);
        }
    }
}
