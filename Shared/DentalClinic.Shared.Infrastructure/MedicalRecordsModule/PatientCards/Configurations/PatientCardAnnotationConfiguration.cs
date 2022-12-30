using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using DentalClinic.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.Shared.Infrastructure.MedicalRecordsModule.PatientCards.Configurations;
internal class PatientCardAnnotationConfiguration : IEntityTypeConfiguration<PatientCardAnnotation>
{
    public void Configure(EntityTypeBuilder<PatientCardAnnotation> builder)
    {
        builder.HasKey(x=>x.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.Contents)
            .HasMaxLength(1000);
    }
}
