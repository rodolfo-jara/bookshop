
using Bookshop.Services.RecompensaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.Services.RecompensaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }
        public DbSet<Recompensa> Recompensas { get; set; }

        


        
    }
}
