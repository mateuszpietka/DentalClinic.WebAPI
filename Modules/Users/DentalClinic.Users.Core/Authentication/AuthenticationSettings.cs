﻿namespace DentalClinic.Users.Core.Authentication;

internal class AuthenticationSettings : IAuthenticationSettings
{
    public string JwtKey { get; set; }
    public int JwtExpireDays { get; set; }
    public string JwtIssuer { get; set; }
}
