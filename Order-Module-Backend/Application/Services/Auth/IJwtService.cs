using System.Security.Claims;

namespace Application.Services.Auth
{
    public interface IJwtService
    {
        string GenerateAccessToken(Guid userId, IEnumerable<string> roles);

        string GenerateRefreshToken();
    }
}
