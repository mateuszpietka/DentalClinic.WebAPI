using DentalClinic.MedicalRecords.Application;
using DentalClinic.MedicalRecords.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.MedicalRecords.Api;

public static class Extensions
{
    public static IServiceCollection AddMedicalRecordsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationLayer();
        services.AddInfrastructureLayer(configuration);

        return services;
    }

    public static IApplicationBuilder UseMedicalRecordsModule(this IApplicationBuilder app)
    {
        return app;
    }
}
