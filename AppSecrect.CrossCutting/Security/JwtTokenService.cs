using AppSecrect.CrossCutting.Security.Interfaces;
using AppSecrect.CrossCutting.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppSecrect.CrossCutting.Security
{
    public class JwtTokenService : ITokenService
    {
        private readonly AppSettings appSettings;
        public JwtTokenService(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        public async Task<string> GenerateToken(Guid id, string name, params string[] roles)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, name));

            var claimsRoles = roles
                .Select(role => new Claim(ClaimTypes.Role, role))
                .ToList();

            if (claimsRoles.Any())
                claims.AddRange(claimsRoles);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(securityTokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
