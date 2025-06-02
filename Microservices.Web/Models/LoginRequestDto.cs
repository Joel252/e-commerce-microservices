using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Microservices.Web.Models
{
    public class LoginRequestDto
    {
        [Required, EmailAddress] public string UserName { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
    }
}