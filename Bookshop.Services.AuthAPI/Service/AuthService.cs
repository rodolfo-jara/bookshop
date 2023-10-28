using Bookshop.Services.AuthAPI.Data;
using Bookshop.Services.AuthAPI.Models;
using Bookshop.Services.AuthAPI.Models.Dto;
using Bookshop.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Bookshop.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        //INYECCION DE DEPENDENCIA
        private readonly AppDbContext _db;
        private readonly UserManager<AplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthService(AppDbContext db, IJwtTokenGenerator jwtTokenGenerator,
            UserManager<AplicationUser>userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AsignarRol(string email, string roleName)
        {
            var user = _db.AplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //CREAR UN RL SI NO EXISTE
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.AplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }

            //if user was found , Generate JWT Token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user,roles);

            UserDto userDTO = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                Celular = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDTO,
                Token = token
            };

            return loginResponseDto;
        }

        public async Task<string> Registro(RegistroRequestDto registroRequestDto)
        {
            AplicationUser user = new()
            {
                UserName = registroRequestDto.Email,
                Email = registroRequestDto.Email,
                NormalizedEmail = registroRequestDto.Email.ToUpper(),
                Name = registroRequestDto.Name,
                PhoneNumber = registroRequestDto.Celular
            };
            try
            {
                var result = await _userManager.CreateAsync(user, registroRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.AplicationUsers.First(u => u.UserName == registroRequestDto.Email);

                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        Celular = userToReturn.PhoneNumber

                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex) { 
                
            }
            return "Error encontrado";
       }
    }
}
