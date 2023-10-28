
using Bookshop.Services.CuponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.Services.CuponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }
        public DbSet<Cupon> Cupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cupon>().HasData(new Cupon
            {
                CuponId = 1,
                CodigoCupon = "100FF",
                Descuento = 10,
                MinCanti = 20
            });
            modelBuilder.Entity<Cupon>().HasData(new Cupon
            {
                CuponId = 2,
                CodigoCupon = "200FF",
                Descuento = 20,
                MinCanti = 40
            });
        }
    }
}
