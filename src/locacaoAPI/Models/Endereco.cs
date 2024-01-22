﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int ClienteID { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }        
        public string Numero { get; set; }
        public string Complemento { get; set; }        
    }
}
