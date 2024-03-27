using ManagementApp.API.Data.Models.MoneyManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementApp.API.Data.Configuration;

public class MoneyAccountConfiguration : IEntityTypeConfiguration<MoneyAccount>
{
    public void Configure(EntityTypeBuilder<MoneyAccount> builder)
    {
        builder.ToTable("MoneyAccounts");
        
        builder.HasKey(moneyAccount => moneyAccount.Id);
        
        builder.HasMany(moneyAccount => moneyAccount.Movements)
            .WithOne(movement => movement.MoneyAccount)
            .HasForeignKey(movement => movement.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(moneyAccount => moneyAccount.MoneyBorrowed)
            .WithOne(movement => movement.Account)
            .HasForeignKey(movement => movement.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(moneyAccount => moneyAccount.Banks)
            .WithOne(bank => bank.Account)
            .HasForeignKey(bank => bank.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(moneyAccount => moneyAccount.Creator)
            .WithMany()
            .HasForeignKey(moneyAccount => moneyAccount.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(moneyAccount => moneyAccount.Updater)
            .WithMany()
            .HasForeignKey(moneyAccount => moneyAccount.UpdaterId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(moneyAccount => moneyAccount.UpdaterId)
            .IsRequired(false);
    }
}