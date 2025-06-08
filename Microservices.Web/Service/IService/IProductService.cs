using Microservices.Web.Models;

namespace Microservices.Web.Service.IService
{
    public interface IProductService
    {
        /// <summary>
        /// Retrieves all products from the product service asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object, which includes the list of products if the operation was successful.</returns>
        Task<ResponseDto?> GetAllProductsAsync();

        /// <summary>
        /// Retrieves a product by its unique identifier asynchronously from the product service.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object, which includes the product details if the operation was successful.</returns>
        Task<ResponseDto?> GetProductByIdAsync(int id);

        /// <summary>
        /// Creates a new product in the product service asynchronously.
        /// </summary>
        /// <param name="productDto">The product data transfer object containing details of the product to be created.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object, which indicates the result of the creation operation and includes the created product details if the operation was successful.</returns>
        Task<ResponseDto?> CreateProductAsync(ProductDto productDto);

        /// <summary>
        /// Updates an existing product in the product service asynchronously.
        /// </summary>
        /// <param name="productDto">The product data transfer object containing updated product information.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object, which indicates whether the operation was successful.</returns>
        Task<ResponseDto?> UpdateProductAsync(ProductDto productDto);

        /// <summary>
        /// Deletes a product by its unique identifier asynchronously from the product service.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object, which indicates the result of the deletion operation.</returns>
        Task<ResponseDto?> DeleteProductAsync(int id);
    }
}