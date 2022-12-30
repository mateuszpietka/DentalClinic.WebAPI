using DentalClinic.MedicalRecords.Application.PatientCards.DTO;
using DentalClinic.MedicalRecords.Application.PatientCards.DTO.Validators;
using DentalClinic.MedicalRecords.Application.Toothing.DTO;
using DentalClinic.MedicalRecords.Application.Toothing.DTO.Validators;
using DentalClinic.MedicalRecords.Application.Toothing.Services;
using DentalClinic.MedicalRecords.Core.Toothing.Services;
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
        services.AddScoped<IValidator<ToothDto>, ToothDtoValidator>();
        services.AddScoped<IValidator<MarkTeethDto>, MarkTeethDtoValidator>();
        services.AddScoped<IPatientToothService, PatientToothService>();

        return services;
    }
}