using Microservices.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.ShoppingCartAPI.Data
{
    public class ShoppingCartDbContext : DbContext
    {
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {
        }
    }
}