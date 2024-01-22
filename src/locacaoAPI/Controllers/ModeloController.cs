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
    public class ModeloController : Controller
    {
        private readonly ILogger<ModeloController> _logger;
        private readonly IModeloRepository _ModeloRepository;

        public ModeloController(ILogger<ModeloController> logger, IModeloRepository modeloRepository)
        {
            _logger = logger;
            _ModeloRepository = modeloRepository;
        }

        [HttpGet]
        [Route("getAllByMarca/{idMarca}")]
        [Authorize]
        public async Task<IActionResult> getAllByMarca(int idMarca)
        {
            try
            {
                return Ok(await _ModeloRepository.getAllByMarca(idMarca));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Marca_getAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
