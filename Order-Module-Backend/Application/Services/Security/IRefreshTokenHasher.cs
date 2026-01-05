namespace Application.Services.Security
{
    public interface IRefreshTokenHasher
    {
        string Hash(string refreshToken);
    }
}
