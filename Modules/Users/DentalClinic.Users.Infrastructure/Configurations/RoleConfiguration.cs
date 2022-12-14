using DentalClinic.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.Users.Infrastructure.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            new Role(1, "Administrator"),
            new Role(2, "Lekarz"),
            new Role(3, "Pracownik recepcji"),
            new Role(4, "Pacjent")
            );
    }
}
