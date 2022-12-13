using Microsoft.Extensions.DependencyInjection;
using MediatR; 

namespace DentalClinic.Users.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Extensions));

        return services;
    }
}
