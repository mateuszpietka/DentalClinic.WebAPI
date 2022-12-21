using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Application.DTO.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.VisitSchedule.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Extensions));
        services.AddAutoMapper(typeof(Extensions));
        services.AddScoped<IValidator<CreateFirstVisitDto>, CreateFirstVisitDtoValidator>();

        return services;
    }
}
