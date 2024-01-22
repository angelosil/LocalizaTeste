using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Models
{    
    public class Operador
    {
        [Required]   
        [Range(1, 99999999)]
        public int Matricula { get; set; }

        [Required]
        public string Nome { get; set; }

        public Usuario usuario { get; set; }

        public Operador()
        {
            usuario = new Usuario();            
        }
    }
}
