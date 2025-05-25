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
        /// <param name="request">The registration request containing user details.</param>
        /// <returns>Returns a 200 status code if the registration is successful or an error response if the data is invalid
        /// or registration process fails.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = "Invalid registration request." });
            }

            var errorMessage = await _authService.Register(request);

            // Check if the registration was successful
            if (errorMessage != string.Empty)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = errorMessage });
            }

            return Ok(new ResponseDto());
        }

        /// <summary>
        /// Authenticates a user based on the provided login credentials.
        /// </summary>
        /// <param name="request">The login request containing the user's credentials.</param>
        /// <returns>An <see cref="IActionResult"/> containing the result of the login operation.  Returns a 200 OK response with
        /// a <see cref="ResponseDto"/> containing the authenticated user details if successful.  Returns a 400 Bad
        /// Request response with an error message if the request is invalid or the credentials are incorrect.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = "The request is incorrect" });
            }

            var response = await _authService.Login(request);

            // Check if the login was successful
            if (response.User == null)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = "Username or password is incorrect" });
            }

            return Ok(new ResponseDto { Result = response });
        }

        /// <summary>
        /// Assigns a role to a user based on the provided request details.
        /// </summary>
        /// <param name="request">The request data containing user email and the role to be assigned.</param>
        /// <returns>An <see cref="IActionResult"/> containing the result of the role assignment operation.
        /// Returns a 200 OK response if successful.  Returns a 400 Bad Request response with an error message if the request
        /// is invalid, the role is incorrect or the request doesn't contain a role.</returns>
        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegisterRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = "The request is incorrect" });
            }

            // Check if the role is valid
            if (request.Role == null)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = "Role is required" });
            }

            var response = await _authService.AssignRole(request.Email, request.Role);
            return Ok(new ResponseDto { Result = response });
        }
    }
}
