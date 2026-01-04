namespace Application.Services.Auth
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        IReadOnlyList<string> Roles { get; }

        bool IsInRole(string role);
    }
}
