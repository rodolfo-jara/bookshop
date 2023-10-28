using Bookshop.Web.Models;
using Bookshop.Web.Service.IService;
using Bookshop.Web.Utility;

namespace Bookshop.Web.Service
{
    public class AuthService : IAuthService
    {
        //INYECCION DE DEPENDENCIA
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        //ASIGNAR UN ROL
        public async Task<ResponseDto?> AsignarRolAsync(RegistroRequestDto registroRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registroRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/AsignarRol"
            }, withBearer: false);
        }

        //INICIAR SESION (LOGIN)
        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/login"
            });
        }


        //registrar un usuario
        public async Task<ResponseDto?> RegistroAsync(RegistroRequestDto registroRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registroRequestDto,
                Url = SD.AuthAPIBase + "/api/auth/register"
            }, withBearer: false);
        }
    }
}
