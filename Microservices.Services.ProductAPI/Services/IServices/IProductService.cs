using Microservices.Services.ProductAPI.Models.DTO;

namespace Microservices.Services.ProductAPI.Services.IServices;

/// <summary>
/// Interface for product-related operations.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Retrieves all available products asynchronously.
    /// </summary>
    /// <returns>A <see cref="ResponseDto"/> containing the list of all products.  The response may include additional
    /// metadata or error details if applicable.</returns>
    Task<ResponseDto> GetAllProductsAsync();

    /// <summary>
    /// Retrieves a product by its ID asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ResponseDto> GetProductByIdAsync(int id);

    /// <summary>
    /// Create a new product asynchronously.
    /// </summary>
    /// <param name="product">The data transfer object containing the updated details of the product. Must not be null.</param>
    /// <returns>A <see cref="ResponseDto"/> containing the result of the update operation, including success status and any
    /// relevant messages.</returns>
    Task<ResponseDto> CreateProductAsync(ProductDto product);

    /// <summary>
    /// Update an existing product asynchronously.
    /// </summary>
    /// <param name="product">The data transfer object containing the updated details of the product.</param>
    /// <returns>A <see cref="ResponseDto"/> containing the result of the update operation, including success status and any
    /// relevant messages.</returns>
    Task<ResponseDto> UpdateProductAsync(ProductDto product);

    /// <summary>
    /// Delete a product by its ID asynchronously.
    /// </summary>
    /// <param name="id">Identifier of the product to be deleted.</param>
    /// <returns>A <see cref="ResponseDto"/> containing the result of the delete operation, including success status and any
    /// relevant messages.</returns>
    Task<ResponseDto> DeleteProductAsync(int id);
}