using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Repositories;
using DentalClinic.VisitSchedule.Core.Services;
using DentalClinic.VisitSchedule.Core.VistSchedule;

namespace DentalClinic.VisitSchedule.Application.Services;
internal class VisitScheduleService : IVisitScheduleService
{
    private readonly IVisitRepository _visitRepository;

    public VisitScheduleService(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }

    public async Task<IEnumerable<IVisitToSchedule>> GetDoctorVisitSchedule(long doctorId, DateTime DateFrom, DateTime DateTo)
    {
        var visits = await _visitRepository.GetAllAsync(x => x.DoctorId == doctorId 
                                                            && x.StartDate >= DateFrom 
                                                            && x.StartDate <= DateTo);
        var visitsToSchedule = new List<IVisitToSchedule>();

        foreach (var visit in visits)
        {
            var dateTo = visit.StartDate.AddHours(visit.VisitType.Hours);
            visitsToSchedule.Add(new VisitToSchedule(visit.Id, visit.StartDate, dateTo, visit.IsFirstVisit));
        }

        return visitsToSchedule;
    }

    public async Task<IEnumerable<IVisitToSchedule>> GetPatientVisitSchedule(long patientId, DateTime DateFrom, DateTime DateTo)
    {
        var visits = await _visitRepository.GetAllAsync(x => x.PatientId == patientId 
                                                            && x.StartDate >= DateFrom 
                                                            && x.StartDate <= DateTo);
        var visitsToSchedule = new List<IVisitToSchedule>();

        foreach (var visit in visits)
        {
            var dateTo = visit.StartDate.AddHours(visit.VisitType.Hours);
            visitsToSchedule.Add(new VisitToSchedule(visit.Id, visit.StartDate, dateTo, visit.IsFirstVisit));
        }

        return visitsToSchedule;
    }

    public async Task<IEnumerable<IVisitToSchedule>> GetReceptionistVisitSchedule(long doctorId, long[] patientIds, DateTime DateFrom, DateTime DateTo)
    {
        IEnumerable<Visit> visits;

        if (patientIds.Length == 0)
        {
            visits = await _visitRepository.GetAllAsync(x => x.DoctorId == doctorId
                                                    && x.StartDate >= DateFrom
                                                    && x.StartDate <= DateTo);
        }
        else
        {
            visits = await _visitRepository.GetAllAsync(x => x.DoctorId == doctorId
                                                                && patientIds.Any(y => y == x.PatientId)
                                                                && x.StartDate >= DateFrom
                                                                && x.StartDate <= DateTo);
        }

        var visitsToSchedule = new List<IVisitToSchedule>();

        foreach (var visit in visits)
        {
            var dateTo = visit.StartDate.AddHours(visit.VisitType.Hours);
            visitsToSchedule.Add(new VisitToSchedule(visit.Id, visit.StartDate, dateTo, visit.IsFirstVisit));
        }

        return visitsToSchedule;
    }
}
