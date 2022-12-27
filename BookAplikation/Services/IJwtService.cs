namespace BookAplikation.Services
{
    public interface IJwtService
    {
        string GetJwtToken(int userId, string role);
    }
}
