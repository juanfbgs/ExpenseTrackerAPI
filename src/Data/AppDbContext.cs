using ExpenseTrackerAPI.Data.Configurations;
using ExpenseTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using MyApi.Data.Configurations;

namespace ExpenseTrackerAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
    }
}