using ManagementApp.API.Data.Models.MoneyManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.API.Data.Configuration;

public class MoneyMovementReasonConfiguration : IEntityTypeConfiguration<MoneyMovementReason>
{
    public void Configure(EntityTypeBuilder<MoneyMovementReason> builder)
    {
        builder.ToTable("MoneyMovementReasons");

        builder.HasKey(moneyMovementReason => moneyMovementReason.Id);

        builder.HasMany(moneyMovementReason => moneyMovementReason.Movements)
            .WithOne(movement => movement.Reason)
            .HasForeignKey(movement => movement.ReasonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(moneyMovementReason => moneyMovementReason.Creator)
            .WithMany()
            .HasForeignKey(moneyMovementReason => moneyMovementReason.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(moneyMovementReason => moneyMovementReason.Updater)
            .WithMany()
            .HasForeignKey(moneyMovementReason => moneyMovementReason.UpdaterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(moneyMovementReason => moneyMovementReason.UpdaterId)
            .IsRequired(false);
    }
}