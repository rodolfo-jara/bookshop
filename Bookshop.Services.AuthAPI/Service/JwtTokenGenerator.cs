using Bookshop.Services.AuthAPI.Models;
using Bookshop.Services.AuthAPI.Service.IService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bookshop.Services.AuthAPI.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        //INYECCCION DE DEPENDENCIA
        private readonly JwtOptions _jwtOptions;
        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }



        public string GenerateToken(AplicationUser aplicationUser,IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

            var claimLista = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email,aplicationUser.Email),
                new Claim(JwtRegisteredClaimNames.Sub,aplicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Name,aplicationUser.UserName)
            };
            claimLista.AddRange(roles.Select(role => new Claim(ClaimTypes.Role,role)));
            //DESECRIPTAR
            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claimLista),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDecriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
