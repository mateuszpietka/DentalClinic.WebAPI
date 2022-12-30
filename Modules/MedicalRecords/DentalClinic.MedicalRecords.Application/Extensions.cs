using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.MedicalRecords.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Extensions));

        return services;
    }
}
