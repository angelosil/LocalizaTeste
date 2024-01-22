using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace locacaoAPI.Interfaces
{
    public interface IClienteRepository    
    {
        Task<Cliente> getPorID(int id);
        Task<Cliente> Insert(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
        Task<IEnumerable<Cliente>> QueryAll();
    }
}
