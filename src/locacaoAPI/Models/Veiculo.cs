using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        
        [Required]
        public string Placa { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public decimal ValorHora { get; set; }

        [Required]
        public int LimitePortaMala { get; set; }

        public Modelo Modelo { get; set; }              

        public Combustivel Combustivel { get; set; }
        public Categoria Categoria { get; set; }

        public Veiculo()
        {
            Modelo = new Modelo();            
            Combustivel = new Combustivel();
            Categoria = new Categoria();
        }

    }
}
