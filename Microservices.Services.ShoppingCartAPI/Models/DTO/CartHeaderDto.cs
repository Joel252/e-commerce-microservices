namespace Microservices.Services.ShoppingCartAPI.Models.DTO;

public class CartHeaderDto
{
    public int CartHeaderId { get; set; }
    public string? UserId { get; set; }
    public string? CouponCode { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal DiscountAmount { get; set; }
}