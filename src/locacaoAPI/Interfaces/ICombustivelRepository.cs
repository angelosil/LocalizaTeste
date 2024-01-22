using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Interfaces
{
    public interface ICombustivelRepository
    {
        Task<Combustivel> getPorID(int id);
        Task<Combustivel> Insert(Combustivel Marca);
        Task<Combustivel> Update(Combustivel Marca);
        Task<Combustivel> Delete(Combustivel Marca);
        Task<IEnumerable<Combustivel>> getAll();
    }
}
