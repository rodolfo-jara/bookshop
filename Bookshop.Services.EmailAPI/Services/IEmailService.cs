using Bookshop.Services.EmailAPI.Message;
using Bookshop.Services.EmailAPI.Models.Dto;

namespace Bookshop.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RecompensasMessage rewardsDto);
    }
}
