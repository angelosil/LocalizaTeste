using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Interfaces
{
    public interface IOperadorRepository
    {
        Task<Operador> getPorMatricula(int matricula);
        void Insert(Operador operador);
        void Update(Operador operador);
        void Delete(Operador operador);        
    }
}
