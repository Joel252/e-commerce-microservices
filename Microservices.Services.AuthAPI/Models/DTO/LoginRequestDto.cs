namespace Microservices.Services.AuthAPI.Models.DTO
{
    public class LoginRequestDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
