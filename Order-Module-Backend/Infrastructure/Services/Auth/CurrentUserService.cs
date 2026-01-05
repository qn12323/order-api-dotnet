using Application.Services.Auth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services.Auth
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// ClaimsPrincipal của request hiện tại
        /// </summary>
        private ClaimsPrincipal? User =>
            _httpContextAccessor.HttpContext?.User;

        /// <summary>
        /// User đã được authenticate hay chưa
        /// </summary>
        public bool IsAuthenticated =>
            User?.Identity?.IsAuthenticated == true;

        /// <summary>
        /// Lấy UserId từ AccessToken (ClaimTypes.NameIdentifier)
        /// </summary>
        public Guid UserId
        {
            get
            {
                if (!IsAuthenticated)
                    throw new UnauthorizedAccessException("User is not authenticated");

                var userIdClaim = User!
                    .FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                    throw new UnauthorizedAccessException("UserId claim is missing");

                return Guid.Parse(userIdClaim.Value);
            }
        }

        /// <summary>
        /// Danh sách role của user hiện tại
        /// </summary>
        public IReadOnlyList<string> Roles
        {
            get
            {
                if (!IsAuthenticated)
                    return Array.Empty<string>();

                return User!
                    .FindAll(ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();
            }
        }

        /// <summary>
        /// Kiểm tra user có thuộc role hay không
        /// </summary>
        public bool IsInRole(string role)
        {
            if (!IsAuthenticated)
                return false;

            return User!.IsInRole(role);
        }
    }
}
