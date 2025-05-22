namespace Microservices.Services.AuthAPI.Models.DTO
{
    /// <summary>
    /// Data transfer object for ApplicationUser.
    /// </summary>
    public class ApplicationUserDto
    {
        public string ID { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
