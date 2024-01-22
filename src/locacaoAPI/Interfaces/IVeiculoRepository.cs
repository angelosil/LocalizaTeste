using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<Veiculo> getPorID(int id);
        Task<Veiculo> Insert(Veiculo veiculo);
        void Update(Veiculo veiculo);
        void Delete(Veiculo veiculo);
        Task<IEnumerable<Veiculo>> getAll();
    }
}
