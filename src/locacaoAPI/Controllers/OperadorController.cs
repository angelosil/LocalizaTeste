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
    public class OperadorController : Controller
    {
        private readonly ILogger<OperadorController> _logger;
        private readonly IOperadorRepository _operadorRepository;

        public OperadorController(ILogger<OperadorController> logger, IOperadorRepository operadorRepository)
        {
            _logger = logger;
            _operadorRepository = operadorRepository;
        }

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<IActionResult> insert([FromBody] Operador operador)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _operadorRepository.Insert(operador);

                return Ok(new
                {
                    resultado = "Operador incluido com sucesso",
                    status = "ok"
                }); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Categoria_getAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}