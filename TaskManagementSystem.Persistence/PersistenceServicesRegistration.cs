using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Persistence.Repositories;

namespace TaskManagementSystem.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TaskManagementDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("TaskManagementDbConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<ICheckItemRepository, CheckItemRepository>();

        return services;
    }
}