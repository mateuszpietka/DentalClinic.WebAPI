using DentalClinic.Users.Core.Entities;
using DentalClinic.VisitSchedule.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DentalClinic.Shared.Infrastructure.Context;

internal class DentalClinicDbContext : DbContext
{
    public DentalClinicDbContext(DbContextOptions<DentalClinicDbContext> options)
        : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<VisitType> VisitTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
