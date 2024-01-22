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
    public class VeiculoController : Controller
    {
        private readonly ILogger<VeiculoController> _logger;
        private readonly IVeiculoRepository _VeiculoRepository;

        public VeiculoController(ILogger<VeiculoController> logger, IVeiculoRepository veiculoRepository)
        {
            _logger = logger;
            _VeiculoRepository = veiculoRepository;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> getAll()
        {
            try
            {
                return Ok(await _VeiculoRepository.getAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Categoria_getAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getPorId/{id}")]
        [Authorize]
        public async Task<IActionResult> getPorId(int id)
        {
            try
            {
                return Ok(await _VeiculoRepository.getPorID(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Categoria_getAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<IActionResult> insert([FromBody] Veiculo veiculo )
        {
            try
            {
                return Ok(await _VeiculoRepository.Insert(veiculo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Categoria_getAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
