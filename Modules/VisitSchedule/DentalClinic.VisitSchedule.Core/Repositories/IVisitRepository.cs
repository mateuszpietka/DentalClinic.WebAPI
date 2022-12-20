using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.VisitSchedule.Core.Entities;

namespace DentalClinic.VisitSchedule.Core.Repositories;
public interface IVisitRepository : IGenericRepository<Visit, long>
{
}
