using DentalClinic.Users.Api;
using DentalClinic.Shared.Core;
using FluentValidation.AspNetCore;
using DentalClinic.Shared.Core.Exceptions;

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
            //
            builder.Services.AddControllers();

            // APP
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseErrorHandling();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //
            app.UseSharedModule();
            app.UseUsersModule();
            //
            app.MapControllers();
            app.Run();
        }
    }
}