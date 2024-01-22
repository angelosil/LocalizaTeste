using locacaoAPI.Interfaces;
using locacaoAPI.Models;
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
    public class AgendamentoController : Controller
    {
        private readonly ILogger<AgendamentoController> _logger;
        private readonly IAgendamentoRepository _AgendamentoMarcaRepository;

        public AgendamentoController(ILogger<AgendamentoController> logger, IAgendamentoRepository agendamentoMarcaRepository)
        {
            _logger = logger;
            _AgendamentoMarcaRepository = agendamentoMarcaRepository;
        }

        [HttpGet]
        [Route("getAllByID/{idAgendamento}")]
        [Authorize]
        public async Task<IActionResult> getAllByID(int idAgendamento)
        {
            try
            {
                return Ok(await _AgendamentoMarcaRepository.getAllByID(idAgendamento));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "AgendamentoController_getAllByID");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getByCliente/{idCliente}")]
        [Authorize]
        public async Task<IActionResult> getAllByCliente(int idCliente)
        {
            try
            {
                return Ok(await _AgendamentoMarcaRepository.getAllByCliente(idCliente));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "AgendamentoController_getAllByCliente");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<IActionResult> Insert([FromBody] Agendamento agendamento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                agendamento = await _AgendamentoMarcaRepository.Insert(agendamento);

                agendamento = await _AgendamentoMarcaRepository.getAllByID(agendamento.Id);

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "AgendamentoController_getAllByCliente");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
