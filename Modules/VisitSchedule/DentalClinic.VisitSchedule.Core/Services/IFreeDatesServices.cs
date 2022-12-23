using DentalClinic.VisitSchedule.Core.Entities;

namespace DentalClinic.VisitSchedule.Core.Services;

public interface IFreeDatesServices
{
    Task<IEnumerable<DateTime>> GetFreeDates(long doctorId, VisitType visitTypeId, DateTime dateFrom, DateTime dateTo);
}
