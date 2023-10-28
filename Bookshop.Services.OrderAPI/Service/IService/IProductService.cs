

using Bookshop.Services.OrderAPI.Models.Dto;

namespace Bookshop.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
