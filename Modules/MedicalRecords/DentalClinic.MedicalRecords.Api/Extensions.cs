using DentalClinic.MedicalRecords.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.MedicalRecords.Api;

public static class Extensions
{
    public static IServiceCollection AddMedicalRecordsModule(this IServiceCollection services)
    {
        services.AddApplicationLayer();

        return services;
    }

    public static IApplicationBuilder UseMedicalRecordsModule(this IApplicationBuilder app)
    {
        return app;
    }
}
