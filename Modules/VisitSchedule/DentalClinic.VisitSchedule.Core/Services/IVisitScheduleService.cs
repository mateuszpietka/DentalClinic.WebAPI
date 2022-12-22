using DentalClinic.VisitSchedule.Core.VistSchedule;

namespace DentalClinic.VisitSchedule.Core.Services;
public interface IVisitScheduleService
{
    Task<IEnumerable<IVisitToSchedule>> GetPatientVisitSchedule(long patientId, DateTime DateFrom, DateTime DateTo);
    Task<IEnumerable<IVisitToSchedule>> GetDoctorVisitSchedule(long doctorId, DateTime DateFrom, DateTime DateTo);
    Task<IEnumerable<IVisitToSchedule>> GetReceptionistVisitSchedule(long doctorId, long[] patientIds, DateTime DateFrom, DateTime DateTo);
}
