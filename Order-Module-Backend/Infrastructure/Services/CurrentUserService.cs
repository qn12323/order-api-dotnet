using Application.Services.Auth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal? User =>
            _httpContextAccessor.HttpContext?.User;

        public Guid UserId
        {
            get
            {
                var userIdClaim = User?.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                    throw new UnauthorizedAccessException("User is not authenticated");

                return Guid.Parse(userIdClaim.Value);
            }
        }

        public IReadOnlyList<string> Roles
        {
            get
            {
                return User?
                    .FindAll(ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList()
                    ?? new List<string>();
            }
        }

        public bool IsInRole(string role)
        {
            return Roles.Any(r =>
                string.Equals(r, role, StringComparison.OrdinalIgnoreCase));
        }
    }
}
