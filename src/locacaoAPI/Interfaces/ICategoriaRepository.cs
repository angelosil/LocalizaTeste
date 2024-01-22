using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> getPorID(int id);
        Task<Categoria> Insert(Categoria Marca);
        Task<Categoria> Update(Categoria Marca);
        Task<Categoria> Delete(Categoria Marca);
        Task<IEnumerable<Categoria>> getAll();
    }
}
