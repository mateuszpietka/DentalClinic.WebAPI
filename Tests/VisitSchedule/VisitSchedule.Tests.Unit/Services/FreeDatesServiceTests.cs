using DentalClinic.VisitSchedule.Application.Services;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Services;
using DentalClinic.VisitSchedule.Core.VistSchedule;
using Moq;
using Xunit;

namespace VisitSchedule.Tests.Unit.Services;
public class FreeDatesServiceTests
{
    private IFreeDatesService _freeDatesService;

    public FreeDatesServiceTests()
    {
        var workHoursService = new WorkHoursService();

        var mockVisitScheduleService = new Mock<IVisitScheduleService>();
        mockVisitScheduleService
            .Setup(x => x.GetDoctorVisitSchedule(It.IsAny<long>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Returns<long, DateTime, DateTime>((id, dateFrom, dateTo) =>
            Task.FromResult(GetVisitToSchedules().AsQueryable()
                                                 .Where(x => x.DateFrom >= dateFrom && x.DateTo <= dateTo)
                                                 .AsEnumerable()));

        _freeDatesService = new FreeDatesService(workHoursService, mockVisitScheduleService.Object);
    }

    [Fact]
    public async Task get_free_dates_one_day_hours_visit_one()
    {
        IEnumerable<DateTime> expected = new List<DateTime>()
        {
            new DateTime(2022, 12, 8, 11, 00, 00),
            new DateTime(2022, 12, 8, 12, 00, 00),
            new DateTime(2022, 12, 8, 16, 00, 00),
            new DateTime(2022, 12, 8, 17, 00, 00),
        };

        var visitType = GetVisitType(1);
        var dateFrom = new DateTime(2022, 12, 8, 00, 00, 00);
        var dateTo = new DateTime(2022, 12, 8, 23, 59, 00);

        var result = await _freeDatesService.GetFreeDates(1L, visitType, dateFrom, dateTo);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_free_dates_one_day_hours_visit_two()
    {
        IEnumerable<DateTime> expected = new List<DateTime>()
        {
            new DateTime(2022, 12, 8, 11, 00, 00),
            new DateTime(2022, 12, 8, 16, 00, 00),
        };

        var visitType = GetVisitType(2);
        var dateFrom = new DateTime(2022, 12, 8, 00, 00, 00);
        var dateTo = new DateTime(2022, 12, 8, 23, 59, 00);

        var result = await _freeDatesService.GetFreeDates(1L, visitType, dateFrom, dateTo);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_free_dates_one_day_hours_visit_three()
    {
        IEnumerable<DateTime> expected = new List<DateTime>();

        var visitType = GetVisitType(3);
        var dateFrom = new DateTime(2022, 12, 8, 00, 00, 00);
        var dateTo = new DateTime(2022, 12, 8, 23, 59, 00);

        var result = await _freeDatesService.GetFreeDates(1L, visitType, dateFrom, dateTo);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_free_dates_one_day_hours_visit_one_when_no_visits()
    {
        IEnumerable<DateTime> expected = new List<DateTime>()
        {
            new DateTime(2022, 12, 14, 08, 00, 00),
            new DateTime(2022, 12, 14, 09, 00, 00),
            new DateTime(2022, 12, 14, 10, 00, 00),
            new DateTime(2022, 12, 14, 11, 00, 00),
            new DateTime(2022, 12, 14, 12, 00, 00),
            new DateTime(2022, 12, 14, 13, 00, 00),
            new DateTime(2022, 12, 14, 14, 00, 00),
            new DateTime(2022, 12, 14, 15, 00, 00),
            new DateTime(2022, 12, 14, 16, 00, 00),
            new DateTime(2022, 12, 14, 17, 00, 00),
        };

        var visitType = GetVisitType(1);
        var dateFrom = new DateTime(2022, 12, 14, 00, 00, 00);
        var dateTo = new DateTime(2022, 12, 14, 23, 59, 00);

        var result = await _freeDatesService.GetFreeDates(1L, visitType, dateFrom, dateTo);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_free_dates_one_day_hours_visit_three_when_no_visits()
    {
        IEnumerable<DateTime> expected = new List<DateTime>()
        {
            new DateTime(2022, 12, 14, 08, 00, 00),
            new DateTime(2022, 12, 14, 09, 00, 00),
            new DateTime(2022, 12, 14, 10, 00, 00),
            new DateTime(2022, 12, 14, 11, 00, 00),
            new DateTime(2022, 12, 14, 12, 00, 00),
            new DateTime(2022, 12, 14, 13, 00, 00),
            new DateTime(2022, 12, 14, 14, 00, 00),
            new DateTime(2022, 12, 14, 15, 00, 00),
        };

        var visitType = GetVisitType(3);
        var dateFrom = new DateTime(2022, 12, 14, 00, 00, 00);
        var dateTo = new DateTime(2022, 12, 14, 23, 59, 00);

        var result = await _freeDatesService.GetFreeDates(1L, visitType, dateFrom, dateTo);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_free_dates_week_hours_visit_one()
    {
        IEnumerable<DateTime> expected = new List<DateTime>()
        {
            new DateTime(2022, 12, 07, 08, 00, 00),
            new DateTime(2022, 12, 07, 09, 00, 00),
            new DateTime(2022, 12, 07, 10, 00, 00),
            new DateTime(2022, 12, 07, 11, 00, 00),
            new DateTime(2022, 12, 07, 12, 00, 00),
            new DateTime(2022, 12, 07, 13, 00, 00),
            new DateTime(2022, 12, 07, 14, 00, 00),
            new DateTime(2022, 12, 07, 15, 00, 00),
            new DateTime(2022, 12, 07, 16, 00, 00),
            new DateTime(2022, 12, 07, 17, 00, 00),

            new DateTime(2022, 12, 08, 11, 00, 00),
            new DateTime(2022, 12, 08, 12, 00, 00),
            new DateTime(2022, 12, 08, 16, 00, 00),
            new DateTime(2022, 12, 08, 17, 00, 00),

            new DateTime(2022, 12, 09, 08, 00, 00),
            new DateTime(2022, 12, 09, 11, 00, 00),
            new DateTime(2022, 12, 09, 12, 00, 00),
            new DateTime(2022, 12, 09, 13, 00, 00),
            new DateTime(2022, 12, 09, 14, 00, 00),
            new DateTime(2022, 12, 09, 15, 00, 00),

            new DateTime(2022, 12, 12, 08, 00, 00),
            new DateTime(2022, 12, 12, 09, 00, 00),
            new DateTime(2022, 12, 12, 11, 00, 00),
            new DateTime(2022, 12, 12, 13, 00, 00),
            new DateTime(2022, 12, 12, 14, 00, 00),
            new DateTime(2022, 12, 12, 15, 00, 00),
            new DateTime(2022, 12, 12, 17, 00, 00),

            new DateTime(2022, 12, 13, 10, 00, 00),
            new DateTime(2022, 12, 13, 11, 00, 00),
            new DateTime(2022, 12, 13, 12, 00, 00),
            new DateTime(2022, 12, 13, 13, 00, 00),
            new DateTime(2022, 12, 13, 14, 00, 00),
            new DateTime(2022, 12, 13, 15, 00, 00),
            new DateTime(2022, 12, 13, 16, 00, 00),
        };

        var visitType = GetVisitType(1);
        var dateFrom = new DateTime(2022, 12, 7, 00, 00, 00);
        var dateTo = new DateTime(2022, 12, 13, 23, 59, 00);

        var result = await _freeDatesService.GetFreeDates(1L, visitType, dateFrom, dateTo);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_free_dates_week_hours_visit_two()
    {
        IEnumerable<DateTime> expected = new List<DateTime>()
        {
            new DateTime(2022, 12, 07, 08, 00, 00),
            new DateTime(2022, 12, 07, 09, 00, 00),
            new DateTime(2022, 12, 07, 10, 00, 00),
            new DateTime(2022, 12, 07, 11, 00, 00),
            new DateTime(2022, 12, 07, 12, 00, 00),
            new DateTime(2022, 12, 07, 13, 00, 00),
            new DateTime(2022, 12, 07, 14, 00, 00),
            new DateTime(2022, 12, 07, 15, 00, 00),
            new DateTime(2022, 12, 07, 16, 00, 00),

            new DateTime(2022, 12, 08, 11, 00, 00),
            new DateTime(2022, 12, 08, 16, 00, 00),

            new DateTime(2022, 12, 09, 11, 00, 00),
            new DateTime(2022, 12, 09, 12, 00, 00),
            new DateTime(2022, 12, 09, 13, 00, 00),
            new DateTime(2022, 12, 09, 14, 00, 00),

            new DateTime(2022, 12, 12, 08, 00, 00),
            new DateTime(2022, 12, 12, 13, 00, 00),
            new DateTime(2022, 12, 12, 14, 00, 00),

            new DateTime(2022, 12, 13, 10, 00, 00),
            new DateTime(2022, 12, 13, 11, 00, 00),
            new DateTime(2022, 12, 13, 12, 00, 00),
            new DateTime(2022, 12, 13, 13, 00, 00),
            new DateTime(2022, 12, 13, 14, 00, 00),
            new DateTime(2022, 12, 13, 15, 00, 00),
        };

        var visitType = GetVisitType(2);
        var dateFrom = new DateTime(2022, 12, 7, 00, 00, 00);
        var dateTo = new DateTime(2022, 12, 13, 23, 59, 00);

        var result = await _freeDatesService.GetFreeDates(1L, visitType, dateFrom, dateTo);

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_free_dates_week_hours_visit_three()
    {
        IEnumerable<DateTime> expected = new List<DateTime>()
        {
            new DateTime(2022, 12, 07, 08, 00, 00),
            new DateTime(2022, 12, 07, 09, 00, 00),
            new DateTime(2022, 12, 07, 10, 00, 00),
            new DateTime(2022, 12, 07, 11, 00, 00),
            new DateTime(2022, 12, 07, 12, 00, 00),
            new DateTime(2022, 12, 07, 13, 00, 00),
            new DateTime(2022, 12, 07, 14, 00, 00),
            new DateTime(2022, 12, 07, 15, 00, 00),

            new DateTime(2022, 12, 09, 11, 00, 00),
            new DateTime(2022, 12, 09, 12, 00, 00),
            new DateTime(2022, 12, 09, 13, 00, 00),

            new DateTime(2022, 12, 12, 13, 00, 00),

            new DateTime(2022, 12, 13, 10, 00, 00),
            new DateTime(2022, 12, 13, 11, 00, 00),
            new DateTime(2022, 12, 13, 12, 00, 00),
            new DateTime(2022, 12, 13, 13, 00, 00),
            new DateTime(2022, 12, 13, 14, 00, 00),
        };

        var visitType = GetVisitType(3);
        var dateFrom = new DateTime(2022, 12, 7, 00, 00, 00);
        var dateTo = new DateTime(2022, 12, 13, 23, 59, 00);

        var result = await _freeDatesService.GetFreeDates(1L, visitType, dateFrom, dateTo);

        Assert.Equal(expected, result);
    }

    private VisitType GetVisitType(int hours)
    {
        return new VisitType()
        {
            Id = 1,
            Description = "Description",
            Hours = hours
        };
    }

    private IEnumerable<IVisitToSchedule> GetVisitToSchedules()
    {
        return new List<IVisitToSchedule>()
        {
            new VisitToSchedule(00, new DateTime(2022, 12, 08, 08, 00, 00), new DateTime(2022, 12, 08, 10, 00, 00), false),
            new VisitToSchedule(01, new DateTime(2022, 12, 08, 10, 00, 00), new DateTime(2022, 12, 08, 11, 00, 00), false),
            new VisitToSchedule(02, new DateTime(2022, 12, 08, 13, 00, 00), new DateTime(2022, 12, 08, 16, 00, 00), false),
            new VisitToSchedule(03, new DateTime(2022, 12, 09, 09, 00, 00), new DateTime(2022, 12, 09, 11, 00, 00), false),
            new VisitToSchedule(04, new DateTime(2022, 12, 09, 16, 00, 00), new DateTime(2022, 12, 09, 17, 00, 00), false),
            new VisitToSchedule(05, new DateTime(2022, 12, 09, 17, 00, 00), new DateTime(2022, 12, 09, 18, 00, 00), false),
            new VisitToSchedule(06, new DateTime(2022, 12, 12, 10, 00, 00), new DateTime(2022, 12, 12, 11, 00, 00), false),
            new VisitToSchedule(07, new DateTime(2022, 12, 12, 12, 00, 00), new DateTime(2022, 12, 12, 13, 00, 00), false),
            new VisitToSchedule(08, new DateTime(2022, 12, 12, 16, 00, 00), new DateTime(2022, 12, 12, 17, 00, 00), false),
            new VisitToSchedule(08, new DateTime(2022, 12, 13, 08, 00, 00), new DateTime(2022, 12, 13, 10, 00, 00), false),
            new VisitToSchedule(10, new DateTime(2022, 12, 13, 17, 00, 00), new DateTime(2022, 12, 13, 18, 00, 00), false),
        };
    }
}