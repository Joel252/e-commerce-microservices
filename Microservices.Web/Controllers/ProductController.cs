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
        // Index action to load the product list in the view
        public async Task<IActionResult> ProductIndex()
        {
            var list = new List<ProductDto>();
            var response = await productService.GetAllProductsAsync();

            if (!response?.IsSuccess == true)
            {
                TempData["error"] = response?.Message;
                return View(list);
            }

            list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response?.Result) ?? "[]");

            return View(list);
        }

        // Action to load the creation product view
        public Task<IActionResult> ProductCreate()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST: Action to process the creation request for a product
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            if (!ModelState.IsValid) return View(productDto);

            var response = await productService.CreateProductAsync(productDto);

            if (!response?.IsSuccess == true)
            {
                TempData["error"] = response?.Message;
                return View(productDto);
            }

            TempData["success"] = "Product created successfully";
            return RedirectToAction("ProductIndex");
        }

        // Action to delete a product by its ID
        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await productService.DeleteProductAsync(productId);

            if (!response?.IsSuccess == true)
            {
                TempData["error"] = response?.Message;
                return RedirectToAction("ProductIndex");
            }

            TempData["success"] = "Product deleted successfully";

            return RedirectToAction("ProductIndex");
        }
    }
}