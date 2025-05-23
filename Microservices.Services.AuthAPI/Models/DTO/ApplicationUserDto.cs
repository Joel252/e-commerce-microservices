namespace Microservices.Services.AuthAPI.Models.DTO
{
    /// <summary>
    /// Data transfer object for ApplicationUser.
    /// </summary>
    public class ApplicationUserDto
    {
        public required string ID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
