using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Models
{
    public class Modelo
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public Marca Marca { get; set; }

        public Modelo()
        {
            Marca = new Marca();
        }
    }
}
