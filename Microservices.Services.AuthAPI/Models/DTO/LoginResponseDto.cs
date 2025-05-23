namespace Microservices.Services.AuthAPI.Models.DTO
{
    public class LoginResponseDto
    {
        public ApplicationUserDto? User { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
