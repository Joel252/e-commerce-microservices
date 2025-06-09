using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microservices.Services.ShoppingCartAPI.Models.DTO;

namespace Microservices.Services.ShoppingCartAPI.Models;

public class CartDetails
{
    [Key]
    public int CartDetailsId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int CartHeaderId { get; set; }
    
    [ForeignKey("CartHeaderId")]
    public required CartHeader CartHeader { get; set; }
    
    [NotMapped]
    public ProductDto? Product { get; set; }
}