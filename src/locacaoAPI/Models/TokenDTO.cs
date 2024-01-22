using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Models
{
    public class TokenDTO
    {
        public string? Data { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
