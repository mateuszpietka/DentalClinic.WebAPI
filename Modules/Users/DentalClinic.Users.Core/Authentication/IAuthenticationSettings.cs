namespace DentalClinic.Users.Core.Authentication;

public interface IAuthenticationSettings
{
    int JwtExpireDay { get; set; }
    string JwtIssuer { get; set; }
    string JwtKey { get; set; }
}