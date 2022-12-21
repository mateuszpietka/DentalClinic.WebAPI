using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Repositories;
using DentalClinic.VisitSchedule.Infrastructure.Context;

namespace DentalClinic.VisitSchedule.Infrastructure.Repositories;

internal class VisitTypeRepository : GenericRepositoryBase<VisitType, int>, IVisitTypeRepository
{
    public VisitTypeRepository(VisitScheduleDbContext context) 
        : base(context)
    {
    }
}
