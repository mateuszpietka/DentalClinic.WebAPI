using DentalClinic.VisitSchedule.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DentalClinic.VisitSchedule.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VisitScheduleDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DentalClinicDbConnection")));

        return services;
    }
}