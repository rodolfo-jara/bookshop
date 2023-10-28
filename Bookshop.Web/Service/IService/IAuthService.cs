using Bookshop.Web.Models;

namespace Bookshop.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegistroAsync(RegistroRequestDto registroRequestDto);
        Task<ResponseDto?> AsignarRolAsync(RegistroRequestDto registroRequestDto);
    }
}
