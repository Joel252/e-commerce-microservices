using Microservices.Services.CouponAPI.Models;
using Microservices.Services.CouponAPI.Models.DTO;
using Microservices.Services.CouponAPI.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Services.CouponAPI.Controllers
{
    /// <summary>
    /// Provides API endpoints for managing coupons operations.
    /// </summary>
    [Route("api/coupon")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly ICouponService _couponService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CouponApiController"/> class.
        /// </summary>
        /// <param name="couponService">Service for handling coupon operations.</param>
        public CouponApiController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        /// <summary>
        /// Retrieves all available coupons.
        /// </summary>
        /// <returns>A list of all coupons.</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _couponService.GetAllCouponsAsync());
        }

        /// <summary>
        /// Retrieves a specific coupon by its ID.
        /// </summary>
        /// <param name="id">The ID of the coupon.</param>
        /// <returns>The coupon if found, or a 404 error if not.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _couponService.GetCouponByIdAsync(id);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        /// <summary>
        /// Retrieves a coupon by its code.
        /// </summary>
        /// <param name="code">The unique code of the coupon (case-insensitive).</param>
        /// <returns>The coupon with the specified code, or a 404 error if not found.</returns>
        [HttpGet]
        [Route("GetByCode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var result = await _couponService.GetCouponByCodeAsync(code);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        /// <summary>
        /// Creates a new coupon.
        /// </summary>
        /// <param name="couponDto">The DTO containing coupon information.</param>
        /// <returns>The created coupon, or an error response if the data is invalid.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CouponDto couponDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = "Invalid model state." });
            }

            var result = await _couponService.CreateCouponAsync(couponDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        /// <summary>
        /// Updates an existing coupon.
        /// </summary>
        /// <param name="dto">The DTO containing updated coupon data.</param>
        /// <returns>The updated coupon, or an error response if the update failed.</returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CouponDto couponDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto { IsSuccess = false, Message = "Invalid model state." });
            }

            var result = await _couponService.UpdateCouponAsync(couponDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        /// <summary>
        /// Deletes a coupon by its ID.
        /// </summary>
        /// <param name="id">The ID of the coupon to delete.</param>
        /// <returns>A success message or a 404 if the coupon was not found.</returns>
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _couponService.DeleteCouponAsync(id);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }
    }
}
