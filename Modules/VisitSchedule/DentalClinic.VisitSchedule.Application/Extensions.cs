using DentalClinic.VisitSchedule.Application.DTO;
using DentalClinic.VisitSchedule.Application.DTO.Validators;
using DentalClinic.VisitSchedule.Application.Services;
using DentalClinic.VisitSchedule.Core.Services;
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
        services.AddScoped<IValidator<CreateVisitDto>, CreateVisitDtoValidator>();
        services.AddScoped<IValidator<DoctorVisitScheduleFilterDto>, DoctorVisitScheduleFilterDtoValidator>();
        services.AddScoped<IValidator<PatientVisitScheduleFilterDto>, PatientVisitScheduleFilterDtoValidator>();
        services.AddScoped<IValidator<ReceptionistVisitScheduleFilterDto>, ReceptionistVisitScheduleFilterDtoValidator>();
        services.AddScoped<IValidator<FreeDatesFilterDto>, FreeDatesFilterDtoValidator>();
        services.AddScoped<IVisitScheduleService, VisitScheduleService>();
        services.AddScoped<IFreeDatesService, FreeDatesService>();
        services.AddScoped<IWorkHoursService, WorkHoursService>();

        return services;
    }
}
