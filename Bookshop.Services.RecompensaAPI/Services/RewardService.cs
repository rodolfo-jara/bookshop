using Bookshop.Services.RecompensaAPI.Data;
using Bookshop.Services.RecompensaAPI.Message;
using Bookshop.Services.RecompensaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Bookshop.Services.RecompensaAPI.Services
{
    public class RewardService : IRewardsService
    {
        private DbContextOptions<AppDbContext> _dbOptions;
        
        public RewardService(DbContextOptions<AppDbContext> dbOptions)
        {
           _dbOptions = dbOptions;
        }

        public async Task UpdateRewards(RecompensasMessage rewardsMessage)
        {
            try
            {
                Recompensa rewards = new()
                {
                    OrderId = rewardsMessage.OrderId,
                    recompensasActividad = rewardsMessage.recompensasActividad,
                    UserId = rewardsMessage.UserId,
                    recompensasFecha = DateTime.Now
                };
                await using var _db = new AppDbContext(_dbOptions);
                await _db.Recompensas.AddAsync(rewards);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
