namespace Microservices.Services.AuthAPI.Models
{
    public class JwtOptions
    {
        public string? Issuer { get; init; }
        public string? Audience { get; init; }
        public string? SecretKey { get; init; }
        public TimeSpan TokenLifetime { get; init; } = TimeSpan.FromHours(1);
    }
}