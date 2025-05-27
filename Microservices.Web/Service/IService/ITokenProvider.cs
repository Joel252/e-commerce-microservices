namespace Microservices.Web.Service.IService;

/// <summary>
/// Interface for token provider.
/// </summary>
public interface ITokenProvider
{
    /// <summary>
    /// Retrieves the token managed by the provider.
    /// </summary>
    /// <returns>The token as a string.</returns>
    public string? GetToken();

    /// <summary>
    /// Assigns a token to be managed by the provider.
    /// </summary>
    /// <param name="token">The token to set.</param>
    public void SetToken(string token);

    /// <summary>
    /// Clears the currently managed token from the provider.
    /// </summary>
    public void ClearToken();
}