using DentalClinic.Users.Core.Entities;
using DentalClinic.VisitSchedule.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.Shared.Infrastructure.VisitScheduleModule.Configurations;

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

        builder.HasOne(x => x.VisitType)
            .WithMany()
            .HasForeignKey(x => x.VisitTypeId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.PatientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
