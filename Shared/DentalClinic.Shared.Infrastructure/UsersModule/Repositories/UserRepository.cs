using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Shared.Infrastructure.Context;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DentalClinic.Shared.Infrastructure.Repositories;

internal class UserRepository : GenericRepositoryBase<User, long>, IUserRepository
{
    public UserRepository(DentalClinicDbContext context)
        : base(context)
    {

    }


    public override async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _table
            .Include(x => x.Role)
            .Include(x => x.Address)
            .ToListAsync();
    }

    public override async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> predicate)
    {
        return await _table
            .Include(x => x.Role)
            .Include(x => x.Address)
            .Where(predicate).ToListAsync();
    }

    public override async Task<User> GetByIdAsync(long id)
    {
        return await _table
            .Include(x => x.Role)
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate)
    {
        return await _table.AnyAsync(predicate);
    }

    public Task<User> GetByEmail(string email)
    {
        return _table.Include(x => x.Role)
                     .Include(x => x.Address)
                     .FirstOrDefaultAsync(x => x.Email == email);
    }
}