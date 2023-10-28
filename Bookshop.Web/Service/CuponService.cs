using Bookshop.Web.Models;
using Bookshop.Web.Service.IService;
using Bookshop.Web.Utility;

namespace Bookshop.Web.Service
{
    public class CuponService : ICuponService
    {
        //INYECCION DE DEPENDENCIA
        private readonly IBaseService _baseService;
        public CuponService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        //CREAR UN CUPON NUEVO
        public async Task<ResponseDto?> CreateCuponAsync(CuponDto cuponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=cuponDto,
                Url = SD.CuponApiBase + "/api/cupon"
            });
        }
        //ELIMINAR UN CUPON
        public async Task<ResponseDto?> DeleteCuponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CuponApiBase + "/api/cupon/" + id
            });
        }

        //LISTAR TODOS LOS CUPONES
        public async Task<ResponseDto?> GetAllCuponAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CuponApiBase + "/api/cupon"
            });
}
        //BUSCAR POR CODIGO DE CUPON
        public async Task<ResponseDto?> GetCuponAsync(string codigoCupon)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CuponApiBase + "/api/cupon/GetByCode"+ codigoCupon
            });
        }

        //BUSCAR POR ID DEL CUPON
        public async Task<ResponseDto?> GetCuponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CuponApiBase + "/api/cupon/" + id
            });
        }
        //EDITAR UN CUPON
        public async Task<ResponseDto?> UpdateCuponAsync(CuponDto cuponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = cuponDto,
                Url = SD.CuponApiBase + "/api/cupon"
            });
        }
    }
}
