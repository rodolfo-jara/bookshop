using Microsoft.AspNetCore.Identity;

namespace Bookshop.Services.AuthAPI.Models
{
    public class AplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
