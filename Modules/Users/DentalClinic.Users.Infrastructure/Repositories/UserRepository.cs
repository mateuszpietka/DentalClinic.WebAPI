using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Repositories;
using DentalClinic.Users.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DentalClinic.Users.Infrastructure.Repositories;

internal class UserRepository : GenericRepositoryBase<User, long>, IUserRepository
{
	public UserRepository(UserDbContext context)
		: base(context)
	{

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