using Microservices.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.ProductAPI.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Teclado Mecánico RGB",
                    Description =
                        "Teclado mecánico con retroiluminación RGB y switches azules para una experiencia de escritura táctil.",
                    Price = 89.99m,
                    Stock = 150,
                    ImageUrl = "https://example.com/images/teclado-rgb.jpg",
                    Category = "Periféricos"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Silla Gamer Ergonomica",
                    Description =
                        "Silla gamer con diseño ergonómico, reposabrazos ajustables y soporte lumbar.",
                    Price = 249.50m,
                    Stock = 75,
                    ImageUrl = "https://example.com/images/silla-gamer.jpg",
                    Category = "Muebles"
                }
            );
        }
    }
}