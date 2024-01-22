using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Services
{
    public interface ICriptografiaService
    {
        string CriptografarSenha(string login, string senha);

        byte[] GerarSalt(string username);
    }
}
