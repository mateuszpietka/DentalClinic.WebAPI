using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Users.Core.Entities;
using System.Linq.Expressions;

namespace DentalClinic.Users.Core.Repositories;

public interface IUserRepository : IGenericRepository<User, long>
{
    Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
    Task<User> GetByEmail(string email);
}