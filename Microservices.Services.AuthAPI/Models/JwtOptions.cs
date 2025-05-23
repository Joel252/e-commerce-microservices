﻿namespace Microservices.Services.AuthAPI.Models
{
    public class JwtOptions
    {
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string? SecretKey { get; set; }
        public TimeSpan TokenLifetime { get; set; } = TimeSpan.FromHours(1);

    }
}
