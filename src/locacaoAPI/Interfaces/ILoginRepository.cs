using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Interfaces
{
    public interface ILoginRepository
    {      
        Task<IEnumerable<Operador>> operadorLogin(LoginDTO loginDTO);

        Task<IEnumerable<Cliente>> clienteLogin(LoginDTO loginDTO);

    }
}
