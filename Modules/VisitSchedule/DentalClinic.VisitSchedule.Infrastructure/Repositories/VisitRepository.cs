using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Infrastructure.Context;

namespace DentalClinic.VisitSchedule.Infrastructure.Repositories;

internal class VisitRepository : GenericRepositoryBase<Visit, long>
{
    public VisitRepository(VisitScheduleDbContext context) 
        : base(context)
    {
    }
}
