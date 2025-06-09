using System.Diagnostics;
using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.Web.Controllers;

public class HomeController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index()
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
    
    [Authorize]
    public async Task<IActionResult> Details(int productId)
    {
        var product = new ProductDto();

        var response = await productService.GetProductByIdAsync(productId);

        if (!response?.IsSuccess == true)
        {
            TempData["error"] = response?.Message;
            return View(product);
        }

        product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response?.Result) ?? "{}");

        return View(product);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}