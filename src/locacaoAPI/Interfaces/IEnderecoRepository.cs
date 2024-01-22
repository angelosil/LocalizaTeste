using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> getPorID(int id);
        void Insert(Endereco endereco);
        void Update(Endereco endereco);
        void Delete(Endereco endereco);
        Task<IEnumerable<Endereco>> getPorCliente(int idCliente);
    }
}
