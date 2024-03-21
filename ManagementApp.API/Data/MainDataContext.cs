using System.Reflection;
using ManagementApp.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.API.Data;

public class MainDataContext(DbContextOptions<MainDataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}