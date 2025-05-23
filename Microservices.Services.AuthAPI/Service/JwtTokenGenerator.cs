using Microservices.Services.AuthAPI.Models;
using Microservices.Services.AuthAPI.Service.IService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Microservices.Services.AuthAPI.Service
{
    /// <summary>
    /// Provides functionality for generating JSON Web Tokens (JWT) for authenticated users.
    /// </summary>
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenGenerator"/> class with the specified JWT options.
        /// </summary>
        /// <param name="jwtOptions">The configuration options used to generate JWT tokens.</param>
        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        /// <summary>
        /// Generates a JSON Web Token (JWT) for the specified user.
        /// </summary>
        /// <param name="applicationUser">The user for whom the token is being generated.</param>
        /// <returns>The generated JWT string</returns>
        public string GenerateToken(ApplicationUser applicationUser)
        {
            // Encode the secret key using ASCII encoding
            var key = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey!);

            // Create a list of claims to include in the token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email!),
                new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName!)
            };

            // Create token descriptor that defines the token's properties
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtOptions.TokenLifetime),
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Create the token using the token descriptor
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
