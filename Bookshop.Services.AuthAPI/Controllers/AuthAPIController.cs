using Bookshop.Services.AuthAPI.Models.Dto;
using Bookshop.Services.AuthAPI.Service.IService;
using Mango.MessageBus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookshop.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
   
    public class AuthApiController : ControllerBase
    {
        //INYECCION DE DEPENDENCIA
        private readonly IAuthService _authService;
        private readonly IMessageBus _messageBus;
        private readonly IConfiguration _configuration;
        protected ResponseDto _response;
        
        public AuthApiController(IAuthService authService,IMessageBus messageBus,IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
            _messageBus = messageBus;
            _response = new ();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Resgistro([FromBody] RegistroRequestDto model)
        {
            var errorMessage = await _authService.Registro(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            await _messageBus.PublishMessage(model.Email, _configuration.GetValue<string>("TopicAndQueueNames:RegisterUserQueue"));
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResonse = await _authService.Login(model);
            if (loginResonse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Usuario y contraseña es incorrecta";
                return BadRequest(_response);
            }
            _response.Result = loginResonse;
            return Ok(_response);
        }

        [HttpPost("AsignarRol")]
        public async Task<IActionResult> AsignarRol([FromBody] RegistroRequestDto model)
        {
            var asignarRol = await _authService.AsignarRol(model.Email, model.Rol.ToUpper());
            if (!asignarRol)
            {
                _response.IsSuccess = false;
                _response.Message = "Error !!!";
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}
