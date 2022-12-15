using DentalClinic.Users.Application.DTO;
using DentalClinic.Users.Application.DTO.Validators;
using DentalClinic.Users.Application.Services;
using DentalClinic.Users.Core.Authentication;
using DentalClinic.Users.Core.Entities;
using DentalClinic.Users.Core.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DentalClinic.Users.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(cfg =>
        {
            var authenticationSetting = services.BuildServiceProvider().CreateScope().ServiceProvider.GetService<IAuthenticationSettings>();

            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = authenticationSetting.JwtIssuer,
                ValidAudience = authenticationSetting.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSetting.JwtKey))
            };
        });

        services.AddMediatR(typeof(Extensions));
        services.AddAutoMapper(typeof(Extensions));
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IValidator<RegisterPatientDto>, RegisterPatientDtoValidator>();
        services.AddScoped<IValidator<SignInDto>, SignInDtoValidator>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
