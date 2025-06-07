using AutoMapper;
using Microservices.Services.ProductAPI.Data;
using Microservices.Services.ProductAPI.Models;
using Microservices.Services.ProductAPI.Models.DTO;
using Microservices.Services.ProductAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.ProductAPI.Services;

/// <summary>
/// Service that provides methods for managing product-related operations.
/// </summary>
public class ProductService : IProductService
{
    private readonly ProductDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductService"/> class.
    /// </summary>
    /// <param name="context">The database context used to access and manage product data.</param>
    /// <param name="mapper">The mapper used to transform data between entities and DTOs.</param>
    public ProductService(ProductDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Async method that retrieves all available products.
    /// </summary>
    /// <returns>A <see cref="ResponseDto"/> containing the result of the operation.  If successful, the  <see
    /// cref="ResponseDto.Result"/> property contains a list of products. If the operation fails, <see
    /// cref="ResponseDto.IsSuccess"/> is <see langword="false"/> and  <see cref="ResponseDto.Message"/> contains
    /// the error message.</returns>
    public async Task<ResponseDto> GetAllProductsAsync()
    {
        var response = new ResponseDto();

        try
        {
            var products = await _context.Products.ToListAsync();
            response.Result = _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }

        return response;
    }

    /// <summary>
    /// Async method that retrieves a product by its ID.
    /// </summary>
    /// <param name="id">Unique identifier of the product.</param>
    /// <returns>A <see cref="ResponseDto"/> containing the result of the operation.  If successful, the  <see
    /// cref="ResponseDto.Result"/> property contains the product details. If the operation fails, <see
    /// cref="ResponseDto.IsSuccess"/> is <see langword="false"/> and  <see cref="ResponseDto.Message"/> contains
    /// the error message.</returns>
    public async Task<ResponseDto> GetProductByIdAsync(int id)
    {
        var response = new ResponseDto();

        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                response.IsSuccess = false;
                response.Message = "Product not found.";
                return response;
            }

            response.Result = _mapper.Map<ProductDto>(product);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }

        return response;
    }

    /// <summary>
    /// Async method that creates a new product.
    /// </summary>
    /// <param name="productDto">The data transfer object containing the details of the new product to be created.</param>
    /// <returns>A <see cref="ResponseDto"/> containing the result of the operation.  If successful, the  <see
    /// cref="ResponseDto.Result"/> property contains the details of the new product. If the operation fails, <see
    /// cref="ResponseDto.IsSuccess"/> is <see langword="false"/> and  <see cref="ResponseDto.Message"/> contains
    /// the error message.</returns>
    public async Task<ResponseDto> CreateProductAsync(ProductDto productDto)
    {
        var response = new ResponseDto();

        try
        {
            var product = _mapper.Map<Product>(productDto);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            response.Result = _mapper.Map<ProductDto>(product);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }

        return response;
    }

    /// <summary>
    /// Async method that updates an existing product.
    /// </summary>
    /// <param name="productDto">The data transfer object containing the details of the product to be updated.</param>
    /// <returns>A <see cref="ResponseDto"/> containing the result of the operation.  If successful, the  <see
    /// cref="ResponseDto.Result"/> property contains the updated product. If the operation fails, <see
    /// cref="ResponseDto.IsSuccess"/> is <see langword="false"/> and  <see cref="ResponseDto.Message"/> contains
    /// the error message.</returns>
    public async Task<ResponseDto> UpdateProductAsync(ProductDto productDto)
    {
        var response = new ResponseDto();

        try
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            response.Result = _mapper.Map<ProductDto>(product);
        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
        }

        return response;
    }

    /// <summary>
    /// Async method that deletes a product by its ID.
    /// </summary>
    /// <param name="id">Unique identifier of the product to delete.</param>
    /// <returns>A <see cref="ResponseDto"/> containing the result of the operation.  If the product is successfully deleted,
    /// <see cref="ResponseDto.IsSuccess"/> is <see langword="true"/>  and <see cref="ResponseDto.Result"/> contains
    /// the deleted product's details.  If the product is not found, <see cref="ResponseDto.IsSuccess"/> is <see
    /// langword="false"/>  and <see cref="ResponseDto.Message"/> contains an error message.</returns>
    public async Task<ResponseDto> DeleteProductAsync(int id)
    {
        var response = new ResponseDto();

        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                response.IsSuccess = false;
                response.Message = "Product not found.";
                return response;
            }
        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
        }

        return response;
    }
}