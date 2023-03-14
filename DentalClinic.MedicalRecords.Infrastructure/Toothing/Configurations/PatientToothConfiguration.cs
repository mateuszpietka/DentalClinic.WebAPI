using DentalClinic.MedicalRecords.Core.Toothing.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.MedicalRecords.Infrastructure.Toothing.Configurations;
internal class PatientToothConfiguration : IEntityTypeConfiguration<PatientTooth>
{
    public void Configure(EntityTypeBuilder<PatientTooth> builder)
    {
        builder.ToTable("PatientTeeth");

        builder.HasKey(x => new { x.PatientId, x.QuadrantCode, x.ToothNumber });

        builder.Property(x => x.QuadrantCode)
            .IsRequired();

        builder.Property(x => x.ToothNumber)
            .IsRequired();

        builder.Property(x => x.Condition)
            .IsRequired();
    }
}
