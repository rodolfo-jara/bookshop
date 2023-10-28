namespace Bookshop.Services.ShoppingCartAPI.Models.Dto
{
    public class CuponDto
    {
        public int CuponId { get; set; }
        public string CodigoCupon { get; set; }
        public double Descuento { get; set; }
        public int MinCanti { get; set; }
    }
}
