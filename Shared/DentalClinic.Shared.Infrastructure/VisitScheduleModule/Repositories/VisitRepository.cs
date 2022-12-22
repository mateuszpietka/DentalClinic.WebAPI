using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Shared.Infrastructure.Context;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DentalClinic.Shared.Infrastructure.Repositories;

internal class VisitRepository : GenericRepositoryBase<Visit, long>, IVisitRepository
{
    public VisitRepository(DentalClinicDbContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<Visit>> GetAllAsync(Expression<Func<Visit, bool>> predicate)
    {
        return await _table.Include(x=>x.VisitType).Where(predicate).ToListAsync();
    }
}
