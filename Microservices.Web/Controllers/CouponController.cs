using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.Web.Controllers
{
    /// <summary>
    /// Controller responsible for handling coupon-related operations, including listing, creating, and deleting coupons.
    /// </summary>
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        // Action to load the coupon list in the view
        public async Task<IActionResult> CouponIndex()
        {
            var list = new List<CouponDto>();
            var response = await _couponService.GetAllCuponsAsync();

            if (!response?.IsSuccess == true)
            {
                TempData["error"] = response?.Message;
                return View(list);
            }

            list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response?.Result) ?? "[]");

            return View(list);
        }

        // Action to load the creation coupon view
        public Task<IActionResult> CouponCreate()
        {
            return Task.FromResult<IActionResult>(View());
        }

        // POST: Action to process the creation request for a coupon
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto coupon)
        {
            if (!ModelState.IsValid) return View(coupon);

            var response = await _couponService.CreateCouponAsync(coupon);

            if (!response?.IsSuccess == true)
            {
                TempData["error"] = response?.Message;
                return View(coupon);
            }

            TempData["success"] = "Coupon created successfully";
            return RedirectToAction("CouponIndex");
        }

        // Action to delete a coupon by its ID
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            var response = await _couponService.DeleteCouponAsync(couponId);

            if (!response?.IsSuccess == true)
            {
                TempData["error"] = response?.Message;
                return RedirectToAction("CouponIndex");
            }

            TempData["success"] = "Coupon deleted successfully";

            return RedirectToAction("CouponIndex");
        }
    }
}