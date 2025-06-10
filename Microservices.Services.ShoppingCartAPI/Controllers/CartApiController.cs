using AutoMapper;
using Microservices.Services.ShoppingCartAPI.Data;
using Microservices.Services.ShoppingCartAPI.Models;
using Microservices.Services.ShoppingCartAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.ShoppingCartAPI.Controllers;

/// <summary>
/// Controller for managing cart operations.
/// </summary>
[Route("api/cart")]
[ApiController]
[Authorize]
public class CartApiController(IMapper mapper, ShoppingCartDbContext dbContext) : ControllerBase
{
    /// <summary>
    /// POST: Creates or updates a cart for a user.
    /// </summary>
    /// <param name="cartDto">The data transfer object containing cart header and cart details.</param>
    /// <returns>A response object indicating the success or failure of the operation, and the updated cart details if successful.</returns>
    [HttpPost("CartUpsert")]
    public async Task<ResponseDto> CartUpsert(CartDto cartDto)
    {
        var response = new ResponseDto();

        try
        {
            // Validate the request
            if (cartDto.CartHeader == null || cartDto.CartDetails == null)
            {
                response.Message = "Cart header or cart details are missing.";
                response.IsSuccess = false;
                return response;
            }

            // Get the cart details
            var incomingCartDetail = cartDto.CartDetails.First();

            // Check if the user already has a cart
            var cartHeader =
                await dbContext.CartHeaders.FirstOrDefaultAsync(ch => ch.UserId == cartDto.CartHeader.UserId);
            if (cartHeader == null)
            {
                // Create a new cart
                cartHeader = mapper.Map<CartHeader>(cartDto.CartHeader);
                dbContext.CartHeaders.Add(cartHeader);
                await dbContext.SaveChangesAsync();
            }

            // Check if the product is already in the cart
            var cartDetails =
                await dbContext.CartDetails.FirstOrDefaultAsync(cd =>
                    cd.ProductId == incomingCartDetail.ProductId &&
                    cd.CartHeaderId == cartHeader.CartHeaderId);
            if (cartDetails == null)
            {
                // Add the product to the cart
                cartDetails = mapper.Map<CartDetails>(incomingCartDetail);
                cartDetails.CartHeaderId = cartHeader.CartHeaderId;
                dbContext.CartDetails.Add(cartDetails);
            }
            else
            {
                // Update the quantity of the product in the cart
                cartDetails.Quantity += incomingCartDetail.Quantity;
            }

            await dbContext.SaveChangesAsync();

            response.Result = new CartDto
            {
                CartHeader = mapper.Map<CartHeaderDto>(cartHeader),
                CartDetails = new List<CartDetailsDto> { mapper.Map<CartDetailsDto>(cartDetails) }
            };
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.IsSuccess = false;
        }

        return response;
    }
}