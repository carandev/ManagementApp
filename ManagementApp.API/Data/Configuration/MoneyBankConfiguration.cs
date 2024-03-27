using ManagementApp.API.Data.Models.MoneyManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.API.Data.Configuration;

public class MoneyBankConfiguration : IEntityTypeConfiguration<MoneyBank>
{
    public void Configure(EntityTypeBuilder<MoneyBank> builder)
    {
        builder.ToTable("MoneyBanks");
        
        builder.HasKey(moneyBank => moneyBank.Id);
        
        builder.HasMany(moneyBank => moneyBank.Movements)
            .WithOne(movement => movement.OriginBank)
            .HasForeignKey(movement => movement.OriginBankId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(moneyBank => moneyBank.MoneyBorrowed)
            .WithOne(movement => movement.OriginBank)
            .HasForeignKey(movement => movement.OriginBankId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(moneyBank => moneyBank.Creator)
            .WithMany()
            .HasForeignKey(moneyBank => moneyBank.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(moneyBank => moneyBank.Updater)
            .WithMany()
            .HasForeignKey(moneyBank => moneyBank.UpdaterId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(moneyBank => moneyBank.UpdaterId)
            .IsRequired(false);
    }
}