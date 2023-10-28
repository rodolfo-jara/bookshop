using Bookshop.Web.Models;

namespace Bookshop.Web.Service.IService
{
    public interface ICartService
    {
       
        Task<ResponseDto?> GetCartByUserIdAsync(string userId);
        Task<ResponseDto?> UpsertCartAsync(CartDto cartDto);
        Task<ResponseDto?> RemoveFromCartAsync(int cartDtaId);
        Task<ResponseDto?> ApplyCuponAsync(CartDto cartDto);
        Task<ResponseDto?> EmailCart(CartDto cartDto);
    }
}
