using DentalClinic.Shared.Core.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.Shared.Core;

public static class Extensions
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddHostedService<DatabaseInitializer>();

        return services;
    }

    public static IApplicationBuilder UseSharedModule(this IApplicationBuilder app)
    {
        return app;
    }
}
