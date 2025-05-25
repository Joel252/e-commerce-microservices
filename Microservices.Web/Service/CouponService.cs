using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;
using static Microservices.Web.Utility.SD;

namespace Microservices.Web.Service
{
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
                RequestType = RequestType.POST,
                Url = SD.CouponAPIBase + RESOURCE,  
                Data = couponDto
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.DELETE,
                Url = SD.CouponAPIBase + $"{RESOURCE}/{id}"
            });
        }

        public async Task<ResponseDto?> GetAllCuponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.GET,
                Url = SD.CouponAPIBase + RESOURCE
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.GET,
                Url = SD.CouponAPIBase + $"{RESOURCE}/GetByCode/{couponCode}"
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.GET,
                Url = SD.CouponAPIBase + $"{RESOURCE}/{id}"
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                RequestType = RequestType.PUT,
                Url = SD.CouponAPIBase + RESOURCE,
                Data = couponDto
            });
        }
    }
}
