using System.ComponentModel.DataAnnotations;
using Bookshop.Web.Utility;
namespace Bookshop.Web.Models
{
    public class ProductDto
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Precio { get; set; }
        public string Autor { get; set; }
        public string CategoriaName { get; set; }
		public string? ImageUrl { get; set; }
		public string? ImageLocalPath { get; set; }

        [Range(1, 100)]
		public int Count { get; set; } = 1;

        [MaxFileSize(1)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile? Image { get; set; }
	}
}
