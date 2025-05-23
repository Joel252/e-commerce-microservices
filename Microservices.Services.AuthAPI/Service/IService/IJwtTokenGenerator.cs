using Microservices.Services.AuthAPI.Models;

namespace Microservices.Services.AuthAPI.Service.IService
{
    /// <summary>
    /// Interface for generating JWT tokens.
    /// </summary>
    public interface IJwtTokenGenerator
    {
        /// <summary>
        /// Generates a secure token for the specified user.
        /// </summary>
        /// <param name="applicationUser">The user for whom the token is being generated.</param>
        /// <returns>A string representing the generated token, which can be used for authentication or authorization purposes.</returns>
        string GenerateToken(ApplicationUser applicationUser);
    }
}
