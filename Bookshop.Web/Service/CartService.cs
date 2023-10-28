using Bookshop.Web.Models;
using Bookshop.Web.Service.IService;
using Bookshop.Web.Utility;

namespace Bookshop.Web.Service
{
    public class CartService : ICartService
    {
        //INYECCION DE DEPENDENCIA
        private readonly IBaseService _baseService;
        public CartService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> ApplyCuponAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppinCartApiBase + "/api/cart/ApplyCoupon"
            });
        }

        public async Task<ResponseDto?> EmailCart(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppinCartApiBase + "/api/cart/EmailCartRequest"
            });
        }

        public async Task<ResponseDto?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ShoppinCartApiBase + "/api/cart/GetCart/" + userId
            });
        }

        

        public async Task<ResponseDto?> RemoveFromCartAsync(int cartDtaId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDtaId,
                Url = SD.ShoppinCartApiBase + "/api/cart/RemoveCart"
            });
        }

        
        public async Task<ResponseDto?> UpsertCartAsync(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppinCartApiBase + "/api/cart/CartUpsert"
            });
        }
    }
}
