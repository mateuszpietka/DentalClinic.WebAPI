using DentalClinic.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Users.Infrastructure.Context;

internal class UserDbContext: DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
