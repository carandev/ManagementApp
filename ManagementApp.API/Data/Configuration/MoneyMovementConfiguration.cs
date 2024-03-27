using ManagementApp.API.Data.Models.MoneyManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.API.Data.Configuration;

public class MoneyMovementConfiguration : IEntityTypeConfiguration<MoneyMovement>
{
    public void Configure(EntityTypeBuilder<MoneyMovement> builder)
    {
        builder.ToTable("MoneyMovements");

        builder.HasKey(moneyMovement => moneyMovement.Id);

        builder.HasOne(moneyMovement => moneyMovement.Creator)
            .WithMany()
            .HasForeignKey(moneyMovement => moneyMovement.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(moneyMovement => moneyMovement.Updater)
            .WithMany()
            .HasForeignKey(moneyMovement => moneyMovement.UpdaterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(moneyMovement => moneyMovement.UpdaterId)
            .IsRequired(false);
    }
}