using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManagementSystem.Application;

public static class ApplicationServicesRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(typeof(ApplicationServicesRegistration));
        // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}