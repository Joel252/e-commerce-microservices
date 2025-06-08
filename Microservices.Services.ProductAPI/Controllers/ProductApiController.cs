using Microservices.Services.ProductAPI.Models.DTO;
using Microservices.Services.ProductAPI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.ProductAPI.Controllers;

/// <summary>
/// Provides API endpoints for managing product operations.
/// </summary>
[ApiController]
[Authorize]
[Route("api/product")]
public class ProductApiController(IProductService productService) : ControllerBase
{
    /// <summary>
    /// Retrieves all available products.
    /// </summary>
    /// <returns>A list of all coupons.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await productService.GetAllProductsAsync());
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The unique product identifier.</param>
    /// <returns>The coupon with the specified code, or a 404 error if not found.</returns>
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await productService.GetProductByIdAsync(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    /// <summary>
    /// Create a new product.
    /// </summary>
    /// <param name="productDto">DTO containing the new product data.</param>
    /// <returns>The created product, or an error response if create failed.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post([FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ResponseDto { IsSuccess = false, Message = "Invalid model state." });
        }

        var result = await productService.CreateProductAsync(productDto);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    /// <summary>
    /// Update an existing product.
    /// </summary>
    /// <param name="productDto">DTO containing updated product data.</param>
    /// <returns>The updated product, or an error response if the update failed.</returns>
    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Put([FromBody] ProductDto productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ResponseDto { IsSuccess = false, Message = "Invalid model state." });
        }

        var result = await productService.UpdateProductAsync(productDto);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    /// <summary>
    /// Delete a product by its ID.
    /// </summary>
    /// <param name="id">Unique product identifier</param>
    /// <returns>A success message or a 404 if the product was not found.</returns>
    [HttpDelete]
    [Route("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await productService.DeleteProductAsync(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }
}