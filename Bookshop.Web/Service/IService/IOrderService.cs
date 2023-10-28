using Bookshop.Web.Models;

namespace Bookshop.Web.Service.IService
{
    public interface IOrderService
    {
        //BUSCAR POR CODIGO DE CUPON
        Task<ResponseDto?> CreateOrder(CartDto cartDto);

        
    }
}
