using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.VisitSchedule.Core.Entities;
using DentalClinic.VisitSchedule.Core.Repositories;
using DentalClinic.VisitSchedule.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DentalClinic.VisitSchedule.Infrastructure.Repositories;

internal class VisitRepository : GenericRepositoryBase<Visit, long>, IVisitRepository
{
    public VisitRepository(VisitScheduleDbContext context)
        : base(context)
    {
    }

    public override async Task<IEnumerable<Visit>> GetAllAsync(Expression<Func<Visit, bool>> predicate)
    {
        return await _table.Include(x => x.VisitType).Where(predicate).ToListAsync();
    }

    public override async Task<Visit> GetByIdAsync(long id)
    {
        return await _table.Include(x => x.VisitType).FirstOrDefaultAsync(x => x.Id == id);
    }
}
