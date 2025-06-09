using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microservices.Services.ShoppingCartAPI.Models;

public class CartHeader
{
    [Key]
    public int CartHeaderId { get; set; }
    public string? UserId { get; set; }
    public string? CouponCode { get; set; }
    
    [NotMapped]
    public decimal TotalPrice { get; set; }
    [NotMapped]
    public decimal DiscountAmount { get; set; }
}