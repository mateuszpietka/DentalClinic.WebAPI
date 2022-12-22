using DentalClinic.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.Shared.Infrastructure.UsersModule.Configurations;

internal class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Street)
            .HasMaxLength(100);

        builder.Property(x => x.HouseNumber)
            .HasMaxLength(10);

        builder.Property(x => x.ApartamentNumber)
            .HasMaxLength(10);

        builder.Property(x => x.PostalCode)
            .HasMaxLength(20);

        builder.Property(x => x.City)
            .HasMaxLength(100);
    }
}
