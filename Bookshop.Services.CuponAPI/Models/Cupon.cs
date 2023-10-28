using System.ComponentModel.DataAnnotations;

namespace Bookshop.Services.CuponAPI.Models
{
    public class Cupon
    {
        [Key]
        public int CuponId { get; set; }
        [Required]
        public string CodigoCupon { get; set; }
        [Required]
        public double Descuento { get; set; }
        public int MinCanti { get; set; }
    }
}
