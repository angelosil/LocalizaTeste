using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        [Required]        
        public DateTime DataAgendamento { get; set; }
        public DateTime? DataRetirada { get; set; }
        public DateTime? DataEntrega { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]        
        public decimal ValorHora { get; set; }

        [Required]
        public decimal TotalHora { get; set; }
        /// <summary>
        /// O valor total é calculo ao gravar no banco de dados
        /// </summary>
        public decimal ValorTotal { get; set; }

        [Required]
        public Veiculo Veiculo { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

    }
}
