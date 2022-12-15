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
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddSharedModule();
            builder.Services.AddUsersModule(configuration);
            //

            // APP
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

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