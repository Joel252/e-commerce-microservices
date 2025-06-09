using AutoMapper;
using Microservices.Services.ShoppingCartAPI.Models;
using Microservices.Services.ShoppingCartAPI.Models.DTO;

namespace Microservices.Services.ShoppingCartAPI
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
                config.CreateMap<CartHeaderDto, CartHeader>();
                config.CreateMap<CartHeader, CartHeaderDto>();
                
                config.CreateMap<CartDetailsDto, CartDetails>();
                config.CreateMap<CartDetails, CartDetailsDto>();
            });

            return mappingConfig;
        }
    }
}