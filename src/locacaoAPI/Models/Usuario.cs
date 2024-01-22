using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Senha { get; set; }
        public int ClienteId { get; set; }
        public UsuarioPerfil usuarioPerfil { get; set; }
        public TokenDTO Token { get; set; }

        public Usuario()
        {
            usuarioPerfil = new UsuarioPerfil();
        }
    }
}
