using DentalClinic.Users.Api;
using DentalClinic.Shared.Core;
using FluentValidation.AspNetCore;

namespace DentalClinicWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // BUILDER
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddControllers();
            //
            builder.Services.AddFluentValidationAutoValidation();//.AddFluentValidationClientsideAdapters(); // sprawdziæ czy dzia³a walidacja
            builder.Services.AddSharedModule();
            builder.Services.AddUsersModule(configuration);
            //

            // APP
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseRouting();
            app.MapControllers();
            //
            app.UseSharedModule();
            app.UseUsersModule();
            //
            app.Run();
        }
    }
}