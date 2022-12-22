using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.VisitSchedule.API;

public static class Extensions
{
    public static IServiceCollection AddVisitScheduleModule(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddCoreLayer(configuration);
        //services.AddApplicationLayer();

        return services;
    }

    public static IApplicationBuilder UseVisitScheduleModule(this IApplicationBuilder app)
    {
        return app;
    }
}
