using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Cpf { get; set; }

        public Usuario Usuario { get; set;}

        public Endereco Endereco { get; set; }

        public Cliente()
        {
            Usuario = new Usuario();
            Endereco = new Endereco();
        }

    }
}
