namespace Microservices.Web.Service.IService;

/// <summary>
/// Interface for user authentication
/// </summary>
public interface IUserAuthenticator
{
    /// <summary>
    /// Authenticates a user in DotNet Core Identity.
    /// </summary>
    /// <param name="token">authentication token string.</param>
    Task AuthenticateUserAsync(string token);
}