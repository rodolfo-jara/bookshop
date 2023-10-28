using Bookshop.Web.Models;
using Bookshop.Web.Service.IService;
using Bookshop.Web.Utility;

namespace Bookshop.Web.Service
{
    public class OrderService : IOrderService
    {
        //INYECCION DE DEPENDENCIA
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        //CREAR UN  NUEVO
        

        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.OrderApiBase + "/api/order/CreateOrder"
            });
        }

        
    }
}
