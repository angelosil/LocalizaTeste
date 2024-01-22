using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Interfaces
{
    public interface IMarcaRepository
    {
        Task<Marca> getPorID(int id);
        Task<Marca> Insert(Marca Marca);
        Task<Marca> Update(Marca Marca);
        Task<Marca> Delete(Marca Marca);
        Task<IEnumerable<Marca>> getAll();
    }
}
