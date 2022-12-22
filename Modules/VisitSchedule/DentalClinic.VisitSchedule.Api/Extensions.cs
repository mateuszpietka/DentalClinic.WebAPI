using DentalClinic.VisitSchedule.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.VisitSchedule.API;

public static class Extensions
{
    public static IServiceCollection AddVisitScheduleModule(this IServiceCollection services)
    {
        services.AddApplicationLayer();

        return services;
    }

    public static IApplicationBuilder UseVisitScheduleModule(this IApplicationBuilder app)
    {
        return app;
    }
}
