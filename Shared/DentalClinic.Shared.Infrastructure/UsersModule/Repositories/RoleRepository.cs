using DentalClinic.Shared.Abstarctions.Repostories;
using DentalClinic.Shared.Infrastructure.Context;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Shared.Infrastructure.Repositories;
internal class RoleRepository : GenericRepositoryBase<Role, int>, IRoleRepository
{
    public RoleRepository(DentalClinicDbContext context)
        : base(context)
    {

    }

    public async Task<Role> GetByNameAsync(string name)
    {
        return await _table.FirstOrDefaultAsync(x => x.Name == name);
    }
}
