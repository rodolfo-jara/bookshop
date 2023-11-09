using System.ComponentModel.DataAnnotations;

namespace Bookshop.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 1000)]
        public double Precio { get; set; }
        public string Autor { get; set; }
        public string CategoriaName { get; set; }
        public string? ImageUrl { get; set; }
		public string? ImageLocalPath { get; set; }
	}
}
