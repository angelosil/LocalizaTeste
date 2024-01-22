using locacaoAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace locacaoAPI.Services
{
    public class JwtToken: IJwtToken
    {
        private string _secretKey;
        private string _issuer;
        private string _audience;
        private readonly IConfiguration _configuration;

        
        public JwtToken(IConfiguration configuration)
        {            
            _configuration = configuration;
        }

        public TokenDTO GenerateToken(string Nome, string Role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Nome),
                    new Claim(ClaimTypes.Role, Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            TokenDTO tokedto = new TokenDTO();
            tokedto.Data = tokenHandler.WriteToken(token);
            tokedto.ValidTo = DateTime.Now.AddHours(1);

            return tokedto;
        }

        public bool ValidateJwtToken(string token)
        {   
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey))
                };

                try
                {
                    ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na validação do token: {ex.Message}");
                    return false;
                }
        }        

    }
}
