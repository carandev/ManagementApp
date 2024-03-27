using ManagementApp.API.Data.Models.MoneyManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.API.Data.Configuration;

public class MoneyBorrowedConfiguration : IEntityTypeConfiguration<MoneyBorrowed>
{
    public void Configure(EntityTypeBuilder<MoneyBorrowed> builder)
    {
        builder.ToTable("MoneyBorrowed");

        builder.HasKey(moneyOwed => moneyOwed.Id);

        builder.HasOne(moneyOwed => moneyOwed.Creator)
            .WithMany()
            .HasForeignKey(moneyOwed => moneyOwed.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(moneyOwed => moneyOwed.Updater)
            .WithMany()
            .HasForeignKey(moneyOwed => moneyOwed.UpdaterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(moneyOwed => moneyOwed.UpdaterId)
            .IsRequired(false);
    }
}