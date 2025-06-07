using System.ComponentModel.DataAnnotations;

namespace Microservices.Services.ProductAPI.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;
    [Range(1, 1000)]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    [MaxLength(2000)]
    public string ImageUrl { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Category { get; set; } = string.Empty;
}