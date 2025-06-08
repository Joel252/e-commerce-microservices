using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.Web.Controllers
{
    /// <summary>
    /// Controller responsible for handling product-related operations, including listing, creating, and deleting products.
    /// </summary>
    public class ProductController(IProductService productService) : Controller
    {
        // Index action to list all products
        public async Task<IActionResult> ProductIndex()
        {
            var list = new List<ProductDto>();
            var response = await productService.GetAllProductsAsync();

            if (response?.IsSuccess == true)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result) ?? "[]");
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        // Create action to create a new product
        public Task<IActionResult> ProductCreate()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST action to create a new product
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            if (!ModelState.IsValid) return View(productDto);

            var response = await productService.CreateProductAsync(productDto);

            if (response?.IsSuccess == true)
            {
                TempData["success"] = "Product created successfully";
                return RedirectToAction("ProductIndex");
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(productDto);
        }

        // Delete action to delete a product
        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await productService.DeleteProductAsync(productId);

            if (response?.IsSuccess == true)
            {
                TempData["success"] = "Product deleted successfully";
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return RedirectToAction("ProductIndex");
        }
    }
}