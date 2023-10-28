using AutoMapper;
using Bookshop.Services.CuponAPI.Models;
using Bookshop.Services.CuponAPI.Models.Dto;

namespace Bookshop.Services.CuponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingCofig = new MapperConfiguration(config =>
            {
                config.CreateMap<CuponDto, Cupon>();
                config.CreateMap<Cupon, CuponDto>();
            });
            return mappingCofig;
        }
    }
}
