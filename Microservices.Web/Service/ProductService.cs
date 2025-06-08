using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;
using static Microservices.Web.Utility.SD;

namespace Microservices.Web.Service
{
    /// <summary>
    /// Provides methods to manage product-related operations by interacting with the Product API.
    /// Implements the <see cref="IProductService"/> interface.
    /// </summary>
    public class ProductService(IBaseService baseService) : IProductService
    {
        private const string RESOURCE = "/api/product";

        /// <summary>
        /// Asynchronously creates a new product by sending a request to the Product API.
        /// </summary>
        /// <param name="productDto">The product data transfer object containing the details of the product to create.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="ResponseDto"/> object with the response from the API.</returns>
        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Post,
                Url = SD.ProductApiBase + RESOURCE,
                Data = productDto
            });
        }

        /// <summary>
        /// Asynchronously deletes a product by sending a delete request to the Product API using the specified product ID.
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="ResponseDto"/> object with the response from the API.</returns>
        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Delete,
                Url = SD.ProductApiBase + $"{RESOURCE}/{id}"
            });
        }

        /// <summary>
        /// Asynchronously retrieves a list of all products by sending a request to the Product API.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="ResponseDto"/> object with the response from the API, including the list of products.</returns>
        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Get,
                Url = SD.ProductApiBase + RESOURCE,
            });
        }

        /// <summary>
        /// Asynchronously retrieves a product by its unique identifier by sending a request to the Product API.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="ResponseDto"/> object with the response from the API.</returns>
        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Get,
                Url = SD.ProductApiBase + $"{RESOURCE}/{id}"
            });
        }

        /// <summary>
        /// Asynchronously updates an existing product by sending a PUT request to the Product API.
        /// </summary>
        /// <param name="productDto">The product data transfer object containing the updated details of the product.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="ResponseDto"/> object with the response from the API.</returns>
        public async Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
        {
            return await baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Put,
                Url = SD.ProductApiBase + RESOURCE,
                Data = productDto
            });
        }
    }
}