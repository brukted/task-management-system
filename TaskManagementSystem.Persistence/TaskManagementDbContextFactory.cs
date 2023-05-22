using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TaskManagementSystem.Persistence;

public class TaskManagementDbContextFactory : IDesignTimeDbContextFactory<TaskManagementDbContext>
{
    public TaskManagementDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory() + "/../TaskManagementSystem.Api")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<TaskManagementDbContext>();
        var connectionString = configurationRoot.GetConnectionString("TaskManagementDbConnectionString");
        builder.UseNpgsql(connectionString);

        return new TaskManagementDbContext(builder.Options);
    }
}