using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Users.Core.Entities;

namespace DentalClinic.Users.Core.Repositories;

public interface IRoleRepository: IGenericRepository<Role, int>
{
    Task<Role> GetByNameAsync(string name);
}
