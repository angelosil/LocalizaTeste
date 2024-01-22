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
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaRepository _CategoriaMarcaRepository;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaRepository categoriaRepository)
        {
            _logger = logger;
            _CategoriaMarcaRepository = categoriaRepository;
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> getAll()
        {
            try
            {
                return Ok(await _CategoriaMarcaRepository.getAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Categoria_getAll");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
