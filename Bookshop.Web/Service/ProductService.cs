using Bookshop.Web.Models;
using Bookshop.Web.Service.IService;
using Bookshop.Web.Utility;

namespace Bookshop.Web.Service
{
    public class ProductService : IProductService
    {
        //INYECCION DE DEPENDENCIA
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        //CREAR UN PRODUCT NUEVO
        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=productDto,
                Url = SD.ProductApiBase + "/api/product",
				ContentType = SD.ContentType.MultipartFormData
			});
        }
        //ELIMINAR UN PRODUCT
        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductApiBase + "/api/product/" + id
            });
        }

        //LISTAR TODOS LOS PRODUCTES
        public async Task<ResponseDto?> GetAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/product"
            });
}
        //BUSCAR POR CODIGO DE PRODUCT
        public async Task<ResponseDto?> GetProductAsync(string codigoProduct)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/product/GetByCode"+ codigoProduct
            });
        }

        //BUSCAR POR ID DEL PRODUCT
        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/product/" + id
            });
        }
        //EDITAR UN PRODUCT
        public async Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductApiBase + "/api/product",
				ContentType = SD.ContentType.MultipartFormData
			});
        }
    }
}
