namespace Microservices.Services.AuthAPI.Models.DTO
{
    public class RegisterRequestDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public required string Password { get; set; }
    }
}
