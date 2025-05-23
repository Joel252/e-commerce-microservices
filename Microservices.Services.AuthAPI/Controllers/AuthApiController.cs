using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.AuthAPI.Controllers
{
    /// <summary>
    /// Controller for managing authentication operations.
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        /// <summary>
        /// Register a new user in the system.
        /// </summary>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok("User registered successfully.");
        }

        /// <summary>
        /// Handles user login requests.
        /// </summary>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok("User logged in successfully.");
        }
    }
}
