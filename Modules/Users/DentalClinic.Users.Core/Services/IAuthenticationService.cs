using DentalClinic.Users.Core.Entities;

namespace DentalClinic.Users.Core.Services;

public interface IAuthenticationService
{
    string GenerateToken(User user);
}
