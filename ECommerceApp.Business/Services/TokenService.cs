using ECommerceApp.Business.Helpers;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceApp.Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;

        public TokenService(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public string CreateToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescripter = new SecurityTokenDescriptor
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.signingKey)),
                SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(
                [
                     new(ClaimTypes.Name, user?.UserName),
                     new(ClaimTypes.Email, user?.Email),
                     new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                ])
            };

            var securityToken = tokenHandler.CreateToken(tokenDescripter);

            return tokenHandler.WriteToken(securityToken);
        }
    }
}
