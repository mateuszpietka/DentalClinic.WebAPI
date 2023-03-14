using DentalClinic.MedicalRecords.Core.PatientCards.Repositories;
using DentalClinic.MedicalRecords.Core.Toothing.Repositories;
using DentalClinic.MedicalRecords.Infrastructure.Context;
using DentalClinic.MedicalRecords.Infrastructure.PatientCards.Repositories;
using DentalClinic.MedicalRecords.Infrastructure.Toothing.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.MedicalRecords.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MedicalRecordsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DentalClinicDbConnection")));
        services.AddScoped<IPatientCardRepository, PatientCardRepository>();
        services.AddScoped<IPatientToothRepository, PatientToothRepository>();

        return services;
    }
}