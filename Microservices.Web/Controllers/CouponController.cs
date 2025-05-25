using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservices.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = [];
            ResponseDto? response = await _couponService.GetAllCuponsAsync();

            if (response?.IsSuccess == true)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result) ?? "[]");
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public Task<IActionResult> CouponCreate()
        {
            return Task.FromResult<IActionResult>(View());
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto coupon)
        {
            if (!ModelState.IsValid) return View(coupon);

            ResponseDto? response = await _couponService.CreateCouponAsync(coupon);

            if (response?.IsSuccess == true)
            {
                TempData["success"] = "Coupon created successfully";
                return RedirectToAction("CouponIndex");
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(coupon);
        }

        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await _couponService.DeleteCouponAsync(couponId);

            if (response?.IsSuccess == true) TempData["success"] = "Coupon deleted successfully";

            return RedirectToAction("CouponIndex");
        }
    }
}