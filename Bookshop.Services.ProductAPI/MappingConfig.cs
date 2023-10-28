using AutoMapper;
using Bookshop.Services.ProductAPI.Models;
using Bookshop.Services.ProductAPI.Models.Dto;

namespace Bookshop.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingCofig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingCofig;
        }
    }
}
