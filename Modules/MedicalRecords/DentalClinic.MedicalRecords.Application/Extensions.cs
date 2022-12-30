using DentalClinic.MedicalRecords.Application.PatientCars.DTO;
using DentalClinic.MedicalRecords.Application.PatientCars.DTO.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.MedicalRecords.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Extensions));
        services.AddAutoMapper(typeof(Extensions));
        services.AddScoped<IValidator<AddPatientCardAnnotationDto>, AddPatientCardAnnotationDtoValidator>();

        return services;
    }
}
