using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace locacaoAPI.Services
{
    public interface IJwtToken
    {        
        bool ValidateJwtToken(string token);
        
        TokenDTO GenerateToken(string Nome, string Role);
    }
}
