namespace Microservices.Web.Models
{
    public class LoginResponseDto
    {
        public ApplicationUserDto? User { get; init; }
        public string Token { get; set; } = string.Empty;
    }
}