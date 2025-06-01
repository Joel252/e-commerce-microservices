using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microservices.Web.Service.IService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Microservices.Web.Service;

/// <summary>
/// Authenticator for users in DotNet Core Identity.
/// </summary>
/// <param name="contextAccessor"></param>
public class UserAuthenticator(IHttpContextAccessor contextAccessor) : IUserAuthenticator
{
    /// <summary>
    /// Authenticates a user based on a JWT token and signs them in using cookie authentication.
    /// </summary>
    /// <param name="token">The JWT token containing user claims.</param>
    public async Task AuthenticateUserAsync(string token)
    {
        // Read the JWT token from the request cookie
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

        // Create a ClaimsIdentity associated with authentication schema from Cookies
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        
        // Add the JWT claims to the ClaimsIdentity
        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
            jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value));
        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
            jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value));
        identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
            jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value));

        // Add a claim that using .NET to User.Identity.Name
        identity.AddClaim(new Claim(ClaimTypes.Name,
            jwt.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value!));

        // Create a ClaimsPrincipal associated with the ClaimsIdentity
        var claimsPrincipal = new ClaimsPrincipal(identity);
        
        // Sign in the user
        await contextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
    }
}