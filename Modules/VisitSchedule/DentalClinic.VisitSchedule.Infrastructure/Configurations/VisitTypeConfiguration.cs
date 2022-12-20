using DentalClinic.VisitSchedule.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.Users.Infrastructure.Configurations;

internal class VisitTypeConfiguration : IEntityTypeConfiguration<VisitType>
{
    public void Configure(EntityTypeBuilder<VisitType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Hours)
            .IsRequired();

        builder.HasData(
            new VisitType()
            {
                Id = 1,
                Description = "Control visit",
                Hours = 1,
            },
            new VisitType()
            {
                Id = 2,
                Description = "Control visit",
                Hours = 1,
            },
            new VisitType()
            {
                Id = 3,
                Description = "Tooth root canal treatment",
                Hours = 2,
            },
            new VisitType()
            {
                Id = 4,
                Description = "Prosthetics",
                Hours = 2,
            },
            new VisitType()
            {
                Id = 5,
                Description = "Putting on an orthodontic appliance",
                Hours = 2,
            },
            new VisitType()
            {
                Id = 6,
                Description = "Tooth extraction",
                Hours = 1,
            });
    }
}