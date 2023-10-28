using Bookshop.Web.Models;
using Bookshop.Web.Service.IService;
using Bookshop.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bookshop.Web.Controllers
{
    public class AuthController : Controller
    {
        //INYECCION DE DEPENDENCIA
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;


        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }
        //INICIAR SESION
        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto();
            return View(loginRequestDto);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _authService.LoginAsync(obj);
           
            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = 
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                await SingInUser(loginResponseDto);
                _tokenProvider.SetToken(loginResponseDto.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View(obj);
            }
        }



        //REGISTRAR
        [HttpGet]
        public IActionResult Registrar()
        {
            var rolList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RolAdmin,Value=SD.RolAdmin },
                new SelectListItem{Text=SD.RolCustomer,Value=SD.RolCustomer }
            };
            ViewBag.RolList = rolList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(RegistroRequestDto obj)
        {
            ResponseDto result = await _authService.RegistroAsync(obj);
            ResponseDto assingRole;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(obj.Rol))
                {
                    obj.Rol = SD.RolCustomer;
                }
                assingRole = await _authService.AsignarRolAsync(obj);
                if (assingRole != null && assingRole.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                TempData["error"] = result.Message;
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RolAdmin,Value=SD.RolAdmin},
                new SelectListItem{Text=SD.RolCustomer,Value=SD.RolCustomer},
            };

            ViewBag.RoleList = roleList;
            return View(obj);
        }


           //CERRAR
        public async Task< IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            
            return RedirectToAction("Index","Home");
        }

        private async Task SingInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(model.Token);
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, 
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(ClaimTypes.Role,
               jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));





            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
