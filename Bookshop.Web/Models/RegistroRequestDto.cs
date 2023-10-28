using System.ComponentModel.DataAnnotations;

namespace Bookshop.Web.Models
{
    public class RegistroRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Celular { get; set; }

        [Required]
        public string Password { get; set; }
        public string? Rol { get; set; }
    }
}
