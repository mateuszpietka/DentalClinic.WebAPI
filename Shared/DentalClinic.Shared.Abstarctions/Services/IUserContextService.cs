using System.Security.Claims;

namespace DentalClinic.Shared.Abstarctions.Services;
public interface IUserContextService
{
    ClaimsPrincipal User { get; }
    long? UserId { get; }
    string RoleName { get; }
}
