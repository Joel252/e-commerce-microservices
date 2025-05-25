using Microservices.Web.Models;

namespace Microservices.Web.Service.IService;

/// <summary>
/// Provides methods for authentication and user management services.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Registers a new user with the provided registration details.
    /// </summary>
    /// <param name="registerRequestDto">An object containing the user's registration details.</param>
    /// <returns>A <see cref="ResponseDto"/> object containing the response details </returns>
    Task<ResponseDto?> Register(RegisterRequestDto registerRequestDto);

    /// <summary>
    /// Log in a user with the provided credentials.
    /// </summary>
    /// <param name="loginRequestDto">An object containing the data required to log in</param>
    /// <returns>A <see cref="ResponseDto"/> object containing the response details </returns>
    Task<ResponseDto?> Login(LoginRequestDto loginRequestDto);

    /// <summary>
    /// Assigns a role to a user based on the provided registration details.
    /// </summary>
    /// <param name="registerRequestDto">An object containing the user's registration details, including the role to assign.</param>
    /// <returns>A <see cref="ResponseDto"/> indicating the success or failure of the role assignment.</returns>
    Task<ResponseDto?> AssignRole(RegisterRequestDto registerRequestDto);
}