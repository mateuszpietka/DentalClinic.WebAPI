using DentalClinic.MedicalRecords.Core.PatientCards.Repositories;
using DentalClinic.Shared.Infrastructure.Context;
using DentalClinic.Shared.Infrastructure.MedicalRecordsModule.PatientCards.Repositories;
using DentalClinic.Shared.Infrastructure.Repositories;
using DentalClinic.Users.Core.Repositories;
using DentalClinic.VisitSchedule.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DentalClinicDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DentalClinicDbConnection")));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IVisitTypeRepository, VisitTypeRepository>();
        services.AddScoped<IPatientCardRepository, PatientCardRepository>();

        return services;
    }
}