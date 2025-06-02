using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Microservices.Web.Models
{
    /// <summary>
    /// DTO that represents the request data for user registration.
    /// </summary>
    public class RegisterRequestDto
    {
        [Required] public string Name { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string PhoneNumber { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
        public string? Role { get; set; }
    }
}