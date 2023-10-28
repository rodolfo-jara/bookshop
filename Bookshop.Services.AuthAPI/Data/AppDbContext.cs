
using Bookshop.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.Services.AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<AplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }
        
        public DbSet<AplicationUser> AplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
