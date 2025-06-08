using Microservices.Web.Models;

namespace Microservices.Web.Service.IService
{
    /// <summary>
    /// Interface for coupon service.
    /// </summary>
    public interface ICouponService
    {
        /// <summary>
        /// Retrieves a coupon's details using the specified coupon code.
        /// </summary>
        /// <param name="couponCode">The code of the coupon to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object with the details of the coupon if found.</returns>
        Task<ResponseDto?> GetCouponAsync(string couponCode);

        /// <summary>
        /// Retrieves the details of all available coupons.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object with the details of all coupons.</returns>
        Task<ResponseDto?> GetAllCuponsAsync();

        /// <summary>
        /// Retrieves a coupon's details using the specified coupon ID.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object with the details of the coupon if found.</returns>
        Task<ResponseDto?> GetCouponByIdAsync(int id);

        /// <summary>
        /// Updates an existing coupon with the provided details.
        /// </summary>
        /// <param name="couponDto">An object containing the updated details of the coupon.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object indicating the success or failure of the update operation.</returns>
        Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto);

        /// <summary>
        /// Creates a new coupon using the specified coupon details.
        /// </summary>
        /// <param name="couponDto">The data transfer object containing the details of the coupon to be created.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object indicating the success or failure of the creation operation.</returns>
        Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto);

        /// <summary>
        /// Deletes a coupon using the specified coupon ID.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a ResponseDto object indicating the success or failure of the operation.</returns>
        Task<ResponseDto?> DeleteCouponAsync(int id);
    }
}