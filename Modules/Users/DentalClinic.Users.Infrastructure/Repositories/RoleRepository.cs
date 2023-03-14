using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Repositories;
using DentalClinic.Users.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Users.Infrastructure.Repositories;
internal class RoleRepository : GenericRepositoryBase<Role, int>, IRoleRepository
{
    public RoleRepository(UsersDbContext context)
        : base(context)
    {

    }

    public async Task<Role> GetByNameAsync(string name)
    {
        return await _table.FirstOrDefaultAsync(x => x.Name == name);
    }
}
