namespace Microservices.Services.AuthAPI.Models.DTO
{
    /// <summary>
    /// DTO that represents the request data for user registration.
    /// </summary>
    public class RegisterRequestDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public required string Password { get; set; }
        public string? Role { get; set; }
    }
}
