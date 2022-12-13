using DentalClinic.Users.Api;
using DentalClinic.Shared.Core;

namespace DentalClinicWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddControllers();
            //
            builder.Services.AddSharedModule();
            builder.Services.AddUsersModule(configuration);
            //
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseAuthorization();
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