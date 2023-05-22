using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Domain;
using TaskManagementSystem.Domain.Common;
using Task = TaskManagementSystem.Domain.Task;

namespace TaskManagementSystem.Persistence;

public class TaskManagementDbContext : DbContext
{
    public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagementDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
        {
            var now = DateTime.Now.ToUniversalTime();
            entry.Entity.UpdatedAt = now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<CheckItem> CheckItems { get; set; }
    public DbSet<Task> Tasks { get; set; }
}