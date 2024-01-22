using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Models
{
    public class LoginDTO
    {
        [Required]
        [StringLength(11,MinimumLength = 1)]
        public string Login { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Password { get; set; }

        [Required]
        public int Perfil { get; set; }
    }
}
