using Education.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.UseCases.AuthServise
{
    public class AuthServise : IAuthServise
    {
        private IConfiguration _config;
        private readonly UserManager<UserModel> _userManager;
        public AuthServise(IConfiguration configuration, UserManager<UserModel> userManager)
        {
            _config = configuration;
            _userManager = userManager;
        }
        public async Task<string> GenerateToken(UserModel user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:SecretKey"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWTSettings:ExpireDate"]!);
            var role = await _userManager.GetRolesAsync(user);
            
            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture),ClaimValueTypes.Integer64),
                new Claim("UserName",user.UserName!),
                new Claim(ClaimTypes.Name,user.FullName!),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim("id",user.Id!),
                new Claim("Role",user.Role!),
            };
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWTSettings:ValidIssuer"],
                audience: _config["JWTSettings:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expirePeriod),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
