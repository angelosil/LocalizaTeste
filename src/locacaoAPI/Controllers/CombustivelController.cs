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
    public class CombustivelController : Controller
    {
        private readonly ILogger<CombustivelController> _logger;
        private readonly ICombustivelRepository _CombustivelMarcaRepository;

        public CombustivelController(ILogger<CombustivelController> logger, ICombustivelRepository combustivelRepository)
        {
            _logger = logger;
            _CombustivelMarcaRepository = combustivelRepository;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> getAll()
        {
            try
            {
                return Ok(await _CombustivelMarcaRepository.getAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Combustivel_getAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
