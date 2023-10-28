using Bookshop.Services.AuthAPI.Models;

namespace Bookshop.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(AplicationUser aplicationUser, IEnumerable<string> roles);
    }
}
