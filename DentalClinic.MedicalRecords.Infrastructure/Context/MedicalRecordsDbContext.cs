using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using DentalClinic.MedicalRecords.Core.Toothing.Entities;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.MedicalRecords.Infrastructure.Context;
internal class MedicalRecordsDbContext : DbContext
{
    public MedicalRecordsDbContext(DbContextOptions<MedicalRecordsDbContext> options)
        : base(options)
    {

    }

    public DbSet<PatientCard> PatientCards { get; set; }
    public DbSet<PatientCardAnnotation> PatientCardAnnotations { get; set; }
    public DbSet<PatientTooth> PatientTeeth { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("medicalRecords");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
