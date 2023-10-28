namespace Bookshop.Services.AuthAPI.Models.Dto
{
    public class RegistroRequestDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Celular { get; set; }
        public string Password { get; set; }
        public string? Rol { get; set; }
    }
}
