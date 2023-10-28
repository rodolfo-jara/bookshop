using Bookshop.Web.Models;

namespace Bookshop.Web.Service.IService
{
    public interface IProductService
    {
        //BUSCAR POR CODIGO DE CUPON
        Task<ResponseDto?> GetProductAsync(string codigoCupon);

        //LISTAR TODOS LOS CUPONES
        Task<ResponseDto?> GetAllProductAsync();

        //BUSCAR POR EL ID DEL CUPON
        Task<ResponseDto?> GetProductByIdAsync(int id);

        //CREAR UN CUPON NUEVO
        Task<ResponseDto?> CreateProductAsync(ProductDto productDto);

        //EDITAR UN CUPON
        Task<ResponseDto?> UpdateProductAsync(ProductDto productDto);

        //ELIMINAR UN CUPON
        Task<ResponseDto?> DeleteProductAsync(int id);
    }
}
