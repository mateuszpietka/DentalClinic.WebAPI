using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.MedicalRecords.Infrastructure.PatientCards.Configurations;
internal class PatientCardAnnotationConfiguration : IEntityTypeConfiguration<PatientCardAnnotation>
{
    public void Configure(EntityTypeBuilder<PatientCardAnnotation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Contents)
            .HasMaxLength(1000);
    }
}
