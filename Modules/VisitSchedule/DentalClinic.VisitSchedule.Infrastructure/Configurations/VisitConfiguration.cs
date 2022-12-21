using DentalClinic.VisitSchedule.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.Users.Infrastructure.Configurations;

internal class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.PatientId);

        builder.HasIndex(x => x.DoctorId);

        builder.Property(x => x.DoctorId)
            .IsRequired();

        builder.Property(x => x.PatientId)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.IsFirstVisit)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(x => x.VisitTypeId)
            .IsRequired();
    }
}
