using locacaoAPI.Models;
using locacaoAPI.Repositories;
using locacaoAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(ILogger<ClienteController> logger, IClienteRepository clienteRepository)
        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<IActionResult> insert([FromBody] Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                cliente = await _clienteRepository.Insert(cliente);

                return Ok(new
                {
                    resultado = "Cliente incluido com sucesso",
                    status = "ok"
                }); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "cliente_insert");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
