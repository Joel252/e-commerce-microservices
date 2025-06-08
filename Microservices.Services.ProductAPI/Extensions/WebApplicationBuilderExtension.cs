using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Microservices.Services.ProductAPI.Extensions;

public static class WebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
    {
        // Retrieve JWT configuration from app-settings
        var secretKey = builder.Configuration["ApiSettings:SecretKey"] ?? string.Empty;
        var issuer = builder.Configuration["ApiSettings:Issuer"];
        var audience = builder.Configuration["ApiSettings:Audience"];

        // Convert the secret to a byte array
        var key = Encoding.ASCII.GetBytes(secretKey);

        // Add authentication services
        builder.Services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience,
            };
        });
        
        return builder;
    }
}