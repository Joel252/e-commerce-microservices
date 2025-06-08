using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;
using static Microservices.Web.Utility.SD;

namespace Microservices.Web.Service
{
    /// <summary>
    /// Provides methods to manage coupon-related operations by interacting with the Coupon API.
    /// Implements the <see cref="ICouponService"/> interface.
    /// </summary>
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        private const string RESOURCE = "/api/coupon";

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Post,
                Url = SD.CouponApiBase + RESOURCE,  
                Data = couponDto
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Delete,
                Url = SD.CouponApiBase + $"{RESOURCE}/{id}"
            });
        }

        public async Task<ResponseDto?> GetAllCuponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Get,
                Url = SD.CouponApiBase + RESOURCE
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Get,
                Url = SD.CouponApiBase + $"{RESOURCE}/GetByCode/{couponCode}"
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Get,
                Url = SD.CouponApiBase + $"{RESOURCE}/{id}"
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.Put,
                Url = SD.CouponApiBase + RESOURCE,
                Data = couponDto
            });
        }
    }
}
