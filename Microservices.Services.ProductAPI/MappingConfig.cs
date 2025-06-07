using AutoMapper;
using Microservices.Services.ProductAPI.Models;
using Microservices.Services.ProductAPI.Models.DTO;

namespace Microservices.Services.ProductAPI;

/// <summary>
/// Static class for configuring AutoMapper mappings.
/// </summary>
public static class MappingConfig
{
    /// <summary>
    ///  Registers the AutoMapper mappings.
    /// </summary>
    /// <returns>AutoMapper configuration.</returns>
    public static MapperConfiguration RegisterMap()
    {
        var mappingConfig = new MapperConfiguration(configure =>
        {
            configure.CreateMap<Product, ProductDto>();
            configure.CreateMap<ProductDto, Product>();
        });

        return mappingConfig;
    }
}