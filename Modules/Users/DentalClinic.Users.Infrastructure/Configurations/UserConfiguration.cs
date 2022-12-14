using DentalClinic.Users.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DentalClinic.Users.Infrastructure.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x=>x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Phone)
            .HasMaxLength(20);

        builder.HasOne(p => p.Address)
            .WithOne(pp => pp.User)
            .HasForeignKey<Address>(pp => pp.UserId);

        builder.HasData(
            new User()
            {
                Id = 1,
                FirstName = "Root",
                LastName = string.Empty,
                Email = "root@dentalclinic.com",
                PasswordHash = "pass",
                RoleId = 1,
            });
    }
}