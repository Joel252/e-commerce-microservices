using AutoMapper;
using Microservices.Services.CouponAPI.Models;
using Microservices.Services.CouponAPI.Models.DTO;

namespace Microservices.Services.CouponAPI
{
    /// <summary>
    /// Static class for configuring AutoMapper mappings.
    /// </summary>
    public static class MappingConfig
    {
        /// <summary>
        ///  Registers the AutoMapper mappings.
        /// </summary>
        /// <returns>AutoMapper configuration.</returns>
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });

            return mappingConfig;
        }
    }
}
