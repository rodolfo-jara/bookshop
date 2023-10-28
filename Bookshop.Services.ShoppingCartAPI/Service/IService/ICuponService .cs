using Bookshop.Services.ShoppingCartAPI.Models.Dto;

namespace Bookshop.Services.ShoppingCartAPI.Service.IService
{
    public interface ICuponService
    {
        Task<CuponDto> GetCoupon(string couponCode);
    }
}
