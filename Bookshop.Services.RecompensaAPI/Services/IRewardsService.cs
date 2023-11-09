
using Bookshop.Services.RecompensaAPI.Message;

namespace Bookshop.Services.RecompensaAPI.Services
{
    public interface IRewardsService
    {
        Task UpdateRewards(RecompensasMessage recompensasMessage);
    }
}
