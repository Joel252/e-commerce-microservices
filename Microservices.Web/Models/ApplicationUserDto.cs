namespace Microservices.Web.Models
{
    /// <summary>
    /// Data transfer object for ApplicationUser.
    /// </summary>
    public class ApplicationUserDto
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
