
using Bookshop.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshop.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Guerra y paz (1864)",
                Precio = 99,
                Autor = "León Tolstói ",
                ImageUrl = "https://th.bing.com/th/id/OIP.5s7sgEWKFdXkyfeb9AAFRgAAAA?pid=ImgDet&rs=1/602*402",
                CategoriaName = "Clásicos"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "La vuelta al mundo en ochenta días (1872)",
                Precio = 99.90,
                Autor = "Julio Verne y Peter Holeinone ",
                ImageUrl = "https://th.bing.com/th/id/R.a4f0e9791c5e8cd4420a166c458236c6?rik=wZALMIra17zTYA&riu=http%3a%2f%2f2.bp.blogspot.com%2f-0j8TFs-A-5s%2fUPaCPHWTtyI%2fAAAAAAAAAmo%2f473HjvPPjkk%2fs1600%2fLA-VUELTA-AL-MUNDO-EN-80-D%c3%8d.jpg&ehk=o7YW8POWHmb1qbAIwjxB4q%2bS4mldeJdS3DLqix4cpW8%3d&risl=&pid=ImgRaw&r=0/602*402",
                CategoriaName = "Aventura"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "El señor de los anillos (1954)",
                Precio = 89.90,
                Autor = "J. R. R. Tolkien",
                ImageUrl = "https://archive.is/zxd7Q/3899704ff0b9fac95ed4a3513aab081f999c1565.jpg",
                CategoriaName = "Fantasía"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Breve historia del mundo (1936)",
                Precio = 90,
                Autor = "Indro Montanelli y Roberto Gervaso",
                ImageUrl = "https://infolibros.org/wp-content/uploads/2020/07/Historia-de-la-Edad-Media.jpg",
                CategoriaName = "Historia "
            });


        }
    }
}
