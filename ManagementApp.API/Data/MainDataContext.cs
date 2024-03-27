using System.Reflection;
using ManagementApp.API.Data.Models;
using ManagementApp.API.Data.Models.MoneyManagement;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.API.Data;

public class MainDataContext(DbContextOptions<MainDataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<MoneyAccount> MoneyAccounts { get; set; } = null!;
    public DbSet<MoneyBank> MoneyBanks { get; set; } = null!;
    public DbSet<MoneyBorrowed> MoneyBorrowed { get; set; } = null!;
    public DbSet<MoneyMovementReason> MoneyMovementReasons { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

public DbSet<ManagementApp.API.Data.Models.MoneyManagement.MoneyMovement> MoneyMovement { get; set; } = default!;
}