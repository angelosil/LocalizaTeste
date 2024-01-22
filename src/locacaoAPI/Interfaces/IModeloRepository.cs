using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Interfaces
{
    public interface IModeloRepository
    {
        Task<Modelo> getPorID(int id);
        Task<Modelo> Insert(Modelo Marca);
        Task<Modelo> Update(Modelo Marca);
        Task<Modelo> Delete(Modelo Marca);
        Task<IEnumerable<Modelo>> getAllByMarca(int idmarca);
    }
}
