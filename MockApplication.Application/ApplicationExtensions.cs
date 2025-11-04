using Microsoft.Extensions.DependencyInjection;
using MockApplication.Application.Users;

namespace MockApplication.Application;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
