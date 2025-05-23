using Microservices.Services.AuthAPI.Models.DTO;
using Microservices.Services.AuthAPI.Service.IService;
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
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthApiController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service used to handle authentication-related operations.</param>
        public AuthApiController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Handles user registration by processing the provided registration request.
        /// </summary>
        /// <param name="requestDto">The registration request containing user details.</param>
        /// <returns>Returns a 200 status code if the registration is successful or an error response if the data is invalid or registration process fails.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = "Invalid registration request." });
            }

            var errorMessage = await _authService.Register(requestDto);

            // Check if the registration was successful
            if (errorMessage != string.Empty)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = errorMessage });
            }

            return Ok(new ResponseDto());
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
