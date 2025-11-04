using MockApplication.Application;
using MockApplication.Domain.Configs;
using MockApplication.Infrastructure;

namespace MockApplication.API;

public static class CustomServices
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DocumentConfig>(configuration.GetSection("DocumentConfig"));

        // Add custom Infrastructure services  here
        services.AddInfrastructureServices();

        // Add custom Application services  here
        services.AddApplicationServices();

        return services;
    }
}
