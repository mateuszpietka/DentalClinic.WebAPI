using DentalClinic.Shared.Abstarctions.Services;
using DentalClinic.Shared.Core.Database;
using DentalClinic.Shared.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.Shared.Core;

public static class Extensions
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddHostedService<DatabaseInitializer>();
        services.AddScoped<IUserContextService, UserContextService>();
        services.AddHttpContextAccessor();

        return services;
    }

    public static IApplicationBuilder UseSharedModule(this IApplicationBuilder app)
    {
        return app;
    }
}
