using Microsoft.AspNetCore.Identity;

namespace Microservices.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string Name { get; set; }
    }
}
