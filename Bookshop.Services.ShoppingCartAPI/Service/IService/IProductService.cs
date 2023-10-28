using Bookshop.Services.ShoppingCartAPI.Models.Dto;

namespace Bookshop.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
