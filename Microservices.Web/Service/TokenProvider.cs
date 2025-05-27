using Microservices.Web.Service.IService;
using Microservices.Web.Utility;

namespace Microservices.Web.Service;

/// <summary>
/// Provides functionality for managing tokens using HTTP request cookies.
/// Implements the <see cref="ITokenProvider"/> interface for token operations.
/// </summary>
public class TokenProvider : ITokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Provides functionality for managing and accessing JWT tokens stored in HTTP request cookies.
    /// </summary>
    public TokenProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Retrieves the JWT token stored in HTTP request cookies, if available.
    /// </summary>
    /// <returns>
    /// The JWT token as a string if present in cookies; otherwise, null.
    /// </returns>
    public string? GetToken()
    {
        return _httpContextAccessor.HttpContext?.Request.Cookies[SD.TokenCookie];
    }

    /// <summary>
    /// Stores the provided token in an HTTP response cookie.
    /// </summary>
    /// <param name="token">The JWT token to be stored in the response cookie.</param>
    public void SetToken(string token)
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
    }

    /// <summary>
    /// Removes the stored JWT token by deleting the associated cookie from the HTTP response.
    /// </summary>
    public void ClearToken()
    {
        _httpContextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
    }
}