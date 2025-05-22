namespace Microservices.Services.AuthAPI.Models.DTO
{
    public class LoginResponseDto
    {
        public required ApplicationUserDto User { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
