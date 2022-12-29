using DentalClinic.Shared.Abstarctions.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DentalClinic.Shared.Core.Services;

internal class UserContextService : IUserContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

    public long? UserId => User == null ? null : (long?)long.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
    public string RoleName => User == null ? string.Empty : User.FindFirst(x => x.Type == ClaimTypes.Role).Value;
}
