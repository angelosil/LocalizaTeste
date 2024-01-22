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
    public class MarcaController : Controller
    {
        private readonly ILogger<MarcaController> _logger;
        private readonly IMarcaRepository _MarcaRepository;

        public MarcaController(ILogger<MarcaController> logger, IMarcaRepository marcaRepository)
        {
            _logger = logger;
            _MarcaRepository = marcaRepository; 
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> getAll()
        {
            try {
                return Ok (await _MarcaRepository.getAll());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, "Marca_getAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
