using Bookshop.Services.AuthAPI.Models.Dto;

namespace Bookshop.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        //REGISTRA NUEVO USUARIO
        Task<string> Registro(RegistroRequestDto registroRequestDto);

        //PARA INICIAR SESION
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        //PARA ASIGNAR LOS ROLES
        Task<bool> AsignarRol(string email, string roleName);

    }
}
