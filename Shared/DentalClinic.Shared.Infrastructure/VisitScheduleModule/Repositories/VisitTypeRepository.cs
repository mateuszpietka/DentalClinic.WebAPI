using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Shared.Infrastructure.Context;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Repositories;

namespace DentalClinic.Shared.Infrastructure.Repositories;

internal class VisitTypeRepository : GenericRepositoryBase<VisitType, int>, IVisitTypeRepository
{
    public VisitTypeRepository(DentalClinicDbContext context)
        : base(context)
    {
    }
}
