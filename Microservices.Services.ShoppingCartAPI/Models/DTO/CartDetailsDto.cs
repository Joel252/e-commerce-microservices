namespace Microservices.Services.ShoppingCartAPI.Models.DTO;

public class CartDetailsDto
{
    public int CartDetailsId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int CartHeaderId { get; set; }
    public CartHeaderDto? CartHeader { get; set; }
    public ProductDto? Product { get; set; }
}