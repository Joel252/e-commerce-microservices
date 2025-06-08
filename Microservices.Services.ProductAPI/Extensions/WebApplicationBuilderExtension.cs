using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Microservices.Services.ProductAPI.Extensions;

public static class WebApplicationBuilderExtension
{
    public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
    {
        // Retrieve JWT configuration from app-settings
        var secretKey = builder.Configuration["JWT:SecretKey"] ?? string.Empty;
        var issuer = builder.Configuration["JWT:Issuer"];
        var audience = builder.Configuration["JWT:Audience"];

        var key = Encoding.ASCII.GetBytes(secretKey);

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