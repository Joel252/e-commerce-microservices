using Microservices.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.AuthAPI.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
