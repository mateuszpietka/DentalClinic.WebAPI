using DentalClinic.Users.Api;
using DentalClinic.Shared.Core;
using FluentValidation.AspNetCore;
using DentalClinic.Shared.Core.Exceptions;
using DentalClinic.VisitSchedule.API;

namespace DentalClinicWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // BUILDER
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            //
            builder.Services.AddErrorHandling();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddSharedModule();
            builder.Services.AddUsersModule(configuration);
            builder.Services.AddVisitScheduleModule(configuration);
            //
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });
            // APP
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("CorsPolicy");
            app.UseErrorHandling();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            //
            app.UseSharedModule();
            app.UseUsersModule();
            app.UseVisitScheduleModule();
            //
            app.MapControllers();
            app.Run();
        }
    }
}