using Microsoft.Extensions.DependencyInjection;
using MockApplication.Infrastructure.Users;

namespace MockApplication.Infrastructure;

public static class InfrastructureExtensions
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
