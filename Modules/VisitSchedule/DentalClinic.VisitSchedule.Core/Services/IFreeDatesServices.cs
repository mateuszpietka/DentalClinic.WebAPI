namespace DentalClinic.VisitSchedule.Core.Services;

public interface IFreeDatesServices
{
    Task<IEnumerable<DateTime>> GetFreeDates(long doctorId, long visitTypeId, DateTime dateFrom, DateTime dateTo);
}
