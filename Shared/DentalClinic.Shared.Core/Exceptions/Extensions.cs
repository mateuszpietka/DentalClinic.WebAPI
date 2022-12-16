using DentalClinic.Shared.Abstarctions.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.Shared.Core.Exceptions;

public static class Extensions
{
    public static IServiceCollection AddErrorHandling(this IServiceCollection services)
    {
        services.AddScoped<ErrorHandlerMiddleware>();
        services.AddSingleton<IExceptionToResponseMapper, DefaultExceptionToResponseMapper>();
        services.AddSingleton<IExceptionCompositionRoot, ExceptionCompositionRoot>();

        return services;
    }

    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        => app.UseMiddleware<ErrorHandlerMiddleware>();
}