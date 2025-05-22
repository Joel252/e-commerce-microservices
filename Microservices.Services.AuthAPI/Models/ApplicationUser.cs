using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Microservices.Services.AuthAPI.Models
{
    /// <summary>
    /// ApplicationUser class that inherits from IdentityUser.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
