using DentalClinic.MedicalRecords.Core.PatientCards.Entities;
using DentalClinic.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.Shared.Infrastructure.MedicalRecordsModule.PatientCards.Configurations;
internal class PatientCardConfiguration : IEntityTypeConfiguration<PatientCard>
{
    public void Configure(EntityTypeBuilder<PatientCard> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.PatientCardAnnotations)
            .WithOne()
            .HasForeignKey(x => x.PatientCardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
