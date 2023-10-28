namespace Bookshop.Services.ProductAPI.Models.Dto
{
    public class ProductDto
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Precio { get; set; }
        public string Autor { get; set; }
        public string CategoriaName { get; set; }
        public string ImageUrl { get; set; }
    }
}
