using Bookshop.Web.Models;

namespace Bookshop.Web.Service.IService
{
    public interface ICuponService
    {
        //BUSCAR POR CODIGO DE CUPON
        Task<ResponseDto?> GetCuponAsync(string codigoCupon);

        //LISTAR TODOS LOS CUPONES
        Task<ResponseDto?> GetAllCuponAsync();

        //BUSCAR POR EL ID DEL CUPON
        Task<ResponseDto?> GetCuponByIdAsync(int id);

        //CREAR UN CUPON NUEVO
        Task<ResponseDto?> CreateCuponAsync(CuponDto cuponDto);

        //EDITAR UN CUPON
        Task<ResponseDto?> UpdateCuponAsync(CuponDto cuponDto);

        //ELIMINAR UN CUPON
        Task<ResponseDto?> DeleteCuponAsync(int id);
    }
}
