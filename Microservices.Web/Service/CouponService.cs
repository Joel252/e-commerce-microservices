using Microservices.Web.Models;
using Microservices.Web.Service.IService;
using Microservices.Web.Utility;
using static Microservices.Web.Utility.SD;

namespace Microservices.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        private const string RESOURCE = "/api/CouponAPI";

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDTO?> CreateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                RequestType = RequestType.POST,
                Url = SD.CouponAPIBase + RESOURCE,  
                Data = couponDTO
            });
        }

        public async Task<ResponseDTO?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                RequestType = RequestType.DELETE,
                Url = SD.CouponAPIBase + $"{RESOURCE}/{id}"
            });
        }

        public async Task<ResponseDTO?> GetAllCuponsAsync()
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                RequestType = RequestType.GET,
                Url = SD.CouponAPIBase + RESOURCE
            });
        }

        public async Task<ResponseDTO?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                RequestType = RequestType.GET,
                Url = SD.CouponAPIBase + $"{RESOURCE}/GetByCode/{couponCode}"
            });
        }

        public async Task<ResponseDTO?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                RequestType = RequestType.GET,
                Url = SD.CouponAPIBase + $"{RESOURCE}/{id}"
            });
        }

        public async Task<ResponseDTO?> UpdateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                RequestType = RequestType.PUT,
                Url = SD.CouponAPIBase + RESOURCE,
                Data = couponDTO
            });
        }
    }
}
