using Microservices.Services.AuthAPI.Models.DTO;

namespace Microservices.Services.AuthAPI.Service.IService
{
    /// <summary>
    /// Interface for authentication-related services.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registers a new user with the provided registration details.
        /// </summary>
        /// <param name="registerRequestDto">An object containing the user's registration details.</param>
        /// <returns>A string containing a message</returns>
        Task<string> Register(RegisterRequestDto registerRequestDto);
        /// <summary>
        /// Login a user with the provided credentials.
        /// </summary>
        /// <param name="loginRequestDto">An object containing the data required to log in</param>
        /// <returns>A <see cref="LoginResponseDto"/> object containing the response details </returns>
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        /// <summary>
        /// Assigns a specified role to a user identified by their email address.
        /// </summary>
        /// <param name="email">The email address of the user to whom the role will be assigned.</param>
        /// <param name="role">The role to be assigned to the user.</param>
        /// <returns>A boolean value indicating whether the role assignment was successful.</returns>
        Task<bool> AssignRole(string email, string role);
    }
}
