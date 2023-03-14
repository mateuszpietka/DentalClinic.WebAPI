using DentalClinic.VisitSchedule.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.VisitSchedule.Infrastructure.Context;
internal class VisitScheduleDbContext : DbContext
{
    public VisitScheduleDbContext(DbContextOptions<VisitScheduleDbContext> options)
        : base(options)
    {

    }

    public DbSet<Visit> Visits { get; set; }
    public DbSet<VisitType> VisitTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("medicalRecords");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
