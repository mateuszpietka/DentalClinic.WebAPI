using DentalClinic.VisitSchedule.Application.Services;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Repositories;
using DentalClinic.VisitSchedule.Core.Services;
using DentalClinic.VisitSchedule.Core.VistSchedule;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace VisitSchedule.Tests.Unit.Services;
public class VisitScheduleServiceTests
{
    private IVisitScheduleService _visitScheduleService;

    public VisitScheduleServiceTests()
    {
        var mockVisitRepository = new Mock<IVisitRepository>();

        mockVisitRepository.Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Visit, bool>>>()))
                           .Returns<Expression<Func<Visit, bool>>>(x => Task.FromResult(GetVisits().AsQueryable().Where(x).AsEnumerable()));

        _visitScheduleService = new VisitScheduleService(mockVisitRepository.Object);
    }

    [Fact]
    public async Task get_all_possible_doctor_visits_test()
    {
        IEnumerable<IVisitToSchedule> expected = new List<IVisitToSchedule>()
        {
            new VisitToSchedule(1, new DateTime(2022, 12, 03, 09, 00, 00), new DateTime(2022, 12, 03, 10, 00, 00), true),
            new VisitToSchedule(2, new DateTime(2022, 12, 03, 10, 00, 00), new DateTime(2022, 12, 03, 12, 00, 00), false),
            new VisitToSchedule(3, new DateTime(2022, 12, 04, 12, 00, 00), new DateTime(2022, 12, 04, 15, 00, 00), false),
        };

        var result = await _visitScheduleService.GetDoctorVisitSchedule(1, new DateTime(2022, 12, 01, 09, 00, 00), new DateTime(2022, 12, 31, 09, 00, 00));

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_doctor_visits_with_one_day_test()
    {
        IEnumerable<IVisitToSchedule> expected = new List<IVisitToSchedule>()
        {
            new VisitToSchedule(1, new DateTime(2022, 12, 03, 09, 00, 00), new DateTime(2022, 12, 03, 10, 00, 00), true),
            new VisitToSchedule(2, new DateTime(2022, 12, 03, 10, 00, 00), new DateTime(2022, 12, 03, 12, 00, 00), false),
        };

        var result = await _visitScheduleService.GetDoctorVisitSchedule(1, new DateTime(2022, 12, 03, 00, 00, 00), new DateTime(2022, 12, 03, 23, 59, 59));

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_all_possible_patient_visits_test()
    {
        IEnumerable<IVisitToSchedule> expected = new List<IVisitToSchedule>()
        {
            new VisitToSchedule(1, new DateTime(2022, 12, 03, 09, 00, 00), new DateTime(2022, 12, 03, 10, 00, 00), true),
            new VisitToSchedule(4, new DateTime(2022, 12, 05, 09, 00, 00), new DateTime(2022, 12, 05, 10, 00, 00), false),
        };

        var result = await _visitScheduleService.GetPatientVisitSchedule(3, new DateTime(2022, 12, 01, 00, 00, 00), new DateTime(2022, 12, 31, 23, 59, 59));

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_patient_visits_with_one_day_test()
    {
        IEnumerable<IVisitToSchedule> expected = new List<IVisitToSchedule>()
        {
            new VisitToSchedule(2, new DateTime(2022, 12, 03, 10, 00, 00), new DateTime(2022, 12, 03, 12, 00, 00), false),
        };

        var result = await _visitScheduleService.GetPatientVisitSchedule(4, new DateTime(2022, 12, 03, 00, 00, 00), new DateTime(2022, 12, 03, 23, 59, 59));

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_all_possible_doctor_visits_for_receptionist_with_all_patients()
    {
        IEnumerable<IVisitToSchedule> expected = new List<IVisitToSchedule>()
        {
            new VisitToSchedule(4, new DateTime(2022, 12, 05, 09, 00, 00), new DateTime(2022, 12, 05, 10, 00, 00), false),
            new VisitToSchedule(5, new DateTime(2022, 12, 05, 10, 00, 00), new DateTime(2022, 12, 05, 12, 00, 00), false),
            new VisitToSchedule(6, new DateTime(2022, 12, 06, 12, 00, 00), new DateTime(2022, 12, 06, 15, 00, 00), false),
            new VisitToSchedule(7, new DateTime(2022, 12, 07, 12, 00, 00), new DateTime(2022, 12, 07, 15, 00, 00), false),
        };

        var result = await _visitScheduleService.GetReceptionistVisitSchedule(2, new long[0], new DateTime(2022, 12, 01, 09, 00, 00), new DateTime(2022, 12, 31, 09, 00, 00));

        Assert.Equal(expected, result);
    }

    [Fact]
    public async Task get_all_possible_doctor_visits_for_receptionist_with_selected_patients()
    {
        IEnumerable<IVisitToSchedule> expected = new List<IVisitToSchedule>()
        {
            new VisitToSchedule(4, new DateTime(2022, 12, 05, 09, 00, 00), new DateTime(2022, 12, 05, 10, 00, 00), false),
            new VisitToSchedule(5, new DateTime(2022, 12, 05, 10, 00, 00), new DateTime(2022, 12, 05, 12, 00, 00), false),
        };

        var result = await _visitScheduleService.GetReceptionistVisitSchedule(2, new long[] { 3, 4 }, new DateTime(2022, 12, 01, 09, 00, 00), new DateTime(2022, 12, 31, 09, 00, 00));

        Assert.Equal(expected, result);
    }

    private IEnumerable<Visit> GetVisits()
    {
        var visitType1 = new VisitType()
        {
            Id = 1,
            Description = "Visit type 1",
            Hours = 1,
        };

        var visitType2 = new VisitType()
        {
            Id = 2,
            Description = "Visit type 2",
            Hours = 2,
        };

        var visitType3 = new VisitType()
        {
            Id = 3,
            Description = "Visit type 3",
            Hours = 3,
        };

        return new List<Visit>()
        {
            new Visit()
            {
                Id = 1,
                DoctorId = 1,
                PatientId = 3,
                IsFirstVisit = true,
                StartDate = new DateTime(2022, 12, 03, 09, 00, 00),
                VisitType = visitType1,
                VisitTypeId = visitType1.Id,
            },
            new Visit()
            {
                Id = 2,
                DoctorId = 1,
                PatientId = 4,
                IsFirstVisit = false,
                StartDate = new DateTime(2022, 12, 03, 10, 00, 00),
                VisitType = visitType2,
                VisitTypeId = visitType2.Id,
            },
            new Visit()
            {
                Id = 3,
                DoctorId = 1,
                PatientId = 5,
                IsFirstVisit = false,
                StartDate = new DateTime(2022, 12, 04, 12, 00, 00),
                VisitType = visitType3,
                VisitTypeId = visitType3.Id,
            },
            new Visit()
            {
                Id = 4,
                DoctorId = 2,
                PatientId = 3,
                IsFirstVisit = false,
                StartDate = new DateTime(2022, 12, 05, 09, 00, 00),
                VisitType = visitType1,
                VisitTypeId = visitType1.Id,
            },
            new Visit()
            {
                Id = 5,
                DoctorId = 2,
                PatientId = 4,
                IsFirstVisit = false,
                StartDate = new DateTime(2022, 12, 05, 10, 00, 00),
                VisitType = visitType2,
                VisitTypeId = visitType2.Id,
            },
            new Visit()
            {
                Id = 6,
                DoctorId = 2,
                PatientId = 5,
                IsFirstVisit = false,
                StartDate = new DateTime(2022, 12, 06, 12, 00, 00),
                VisitType = visitType3,
                VisitTypeId = visitType3.Id,
            },
            new Visit()
            {
                Id = 7,
                DoctorId = 2,
                PatientId = 6,
                IsFirstVisit = false,
                StartDate = new DateTime(2022, 12, 07, 12, 00, 00),
                VisitType = visitType3,
                VisitTypeId = visitType3.Id,
            },
        };
    }
}
