namespace DentalClinic.Users.Core.Authentication;

internal class AuthenticationSettings : IAuthenticationSettings
{
    public string JwtKey { get; set; }
    public int JwtExpireDay { get; set; }
    public string JwtIssuer { get; set; }
}
