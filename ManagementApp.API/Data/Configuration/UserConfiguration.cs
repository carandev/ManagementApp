using ManagementApp.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.API.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.Property(user => user.FullName)
            .IsRequired()
            .HasMaxLength(User.MaxFullNameLength);

        builder.Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(User.MaxEmailLength);
    }
}