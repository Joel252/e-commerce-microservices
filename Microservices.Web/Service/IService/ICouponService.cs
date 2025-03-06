using Microservices.Web.Models;

namespace Microservices.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO?> GetCouponAsync(string couponCode);
        Task<ResponseDTO?> GetAllCuponsAsync();
        Task<ResponseDTO?> GetCouponByIdAsync(int id);
        Task<ResponseDTO?> UpdateCouponAsync(CouponDTO coupon);
        Task<ResponseDTO?> CreateCouponAsync(CouponDTO coupon);
        Task<ResponseDTO?> DeleteCouponAsync(int id);
    }
}
