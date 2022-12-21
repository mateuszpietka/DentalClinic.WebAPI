using DentalClinic.VisitSchedule.Core.Repositories;
using DentalClinic.VisitSchedule.Infrastructure.Context;
using DentalClinic.VisitSchedule.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.VisitSchedule.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VisitScheduleDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DentalClinicDbConnection")));
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IVisitTypeRepository, VisitTypeRepository>();

        return services;
    }
}