using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<Agendamento> Insert(Agendamento agendamento);

        Task<IEnumerable<Agendamento>> getAllByCliente(int idCliente);

        Task<Agendamento> getAllByID(int id);
    }
}
