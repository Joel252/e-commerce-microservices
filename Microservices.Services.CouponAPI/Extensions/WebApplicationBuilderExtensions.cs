using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Microservices.Services.CouponAPI.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
    {
        // Get the secret key and other settings from the app settings
        var secret = builder.Configuration["ApiSettings:SecretKey"] ?? string.Empty;
        var issuer = builder.Configuration["ApiSettings:Issuer"];
        var audience = builder.Configuration["ApiSettings:Audience"];

        // Convert the secret to a byte array
        var key = Encoding.ASCII.GetBytes(secret);

        // Add authentication services
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidateAudience = true,
                ValidAudience = audience
            };
        });

        return builder;
    }
}