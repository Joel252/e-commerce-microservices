using Microservices.Services.CouponAPI.Models.DTO;

namespace Microservices.Services.CouponAPI.Services.IService
{
    /// <summary>
    /// Interface for coupon-related operations.
    /// </summary>
    public interface ICouponService
    {
        /// <summary>
        /// Retrieves all available coupons asynchronously.
        /// </summary>
        /// <returns>A <see cref="ResponseDto"/> containing the list of all coupons.  The response may include additional
        /// metadata or error details if applicable.</returns>
        Task<ResponseDto> GetAllCouponsAsync();

        /// <summary>
        /// Retrieves the details of a coupon by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon to retrieve. Must be a positive integer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="ResponseDto"/>
        /// object with the details of the coupon if found, or an appropriate error message if the coupon does not
        /// exist.</returns>
        Task<ResponseDto> GetCouponByIdAsync(int id);

        /// <summary>
        /// Retrieves a coupon by its unique code.
        /// </summary>
        /// <param name="code">The unique code of the coupon to retrieve. Cannot be null or empty.</param>
        /// <returns>A <see cref="ResponseDto"/> containing the details of the coupon if found;  otherwise, an appropriate
        /// response indicating the coupon was not found.</returns>
        Task<ResponseDto> GetCouponByCodeAsync(string code);

        /// <summary>
        /// Creates a new coupon asynchronously.
        /// </summary>
        /// <param name="couponDto">The data transfer object containing the details of the coupon to be created. Cannot be null.</param>
        /// <returns>A <see cref="ResponseDto"/> containing the result of the operation, including success status and any
        /// relevant messages.</returns>
        Task<ResponseDto> CreateCouponAsync(CouponDto couponDto);

        /// <summary>
        /// Updates an existing coupon with the specified details.
        /// </summary>
        /// <param name="couponDto">The data transfer object containing the updated details of the coupon. Must not be null.</param>
        /// <returns>A <see cref="ResponseDto"/> containing the result of the update operation, including success status and any
        /// relevant messages.</returns>
        Task<ResponseDto> UpdateCouponAsync(CouponDto couponDto);

        /// <summary>
        /// Deletes a coupon with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the coupon to delete. Must be a positive integer.</param>
        /// <returns>A <see cref="ResponseDto"/> containing the result of the delete operation, including success status and any
        /// relevant messages.</returns>
        Task<ResponseDto> DeleteCouponAsync(int id);
    }
}