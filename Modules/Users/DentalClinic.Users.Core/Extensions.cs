using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.Users.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        return services;
    }
}