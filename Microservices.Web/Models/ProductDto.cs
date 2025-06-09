using System.ComponentModel.DataAnnotations;

namespace Microservices.Web.Models;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    [Range(1, int.MaxValue)] public int Stock { get; set; }
    public string ImageUrl { get; set; }
    public string Category { get; set; }
    [Range(1, int.MaxValue)] public int Count { get; set; }
}