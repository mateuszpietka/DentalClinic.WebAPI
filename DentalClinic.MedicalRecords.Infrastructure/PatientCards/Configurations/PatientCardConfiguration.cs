using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.MedicalRecords.Infrastructure.PatientCards.Configurations;
internal class PatientCardConfiguration : IEntityTypeConfiguration<PatientCard>
{
    public void Configure(EntityTypeBuilder<PatientCard> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.PatientCardAnnotations)
            .WithOne()
            .HasForeignKey(x => x.PatientCardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
