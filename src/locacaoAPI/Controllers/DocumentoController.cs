using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentoController : Controller
    {
        private readonly ILogger<DocumentoController> _logger;
        private const string PdfFolderPath = "documentos";
        private const string PdfFileName = "modelo-locacao-de-veiculo.pdf";


        public DocumentoController(ILogger<DocumentoController> logger)
        {
            _logger = logger;            
        }

        [HttpGet]
        [Route("getModeloContrato")]
        [Authorize]
        public IActionResult getModeloContrato()
        {
            try {

                string pdfPath = Path.Combine(PdfFolderPath, PdfFileName);

                if (!System.IO.File.Exists(pdfPath))
                {
                    return NotFound("Arquivo PDF não encontrado.");
                }

                byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfPath);

                return File(pdfBytes, "application/pdf", PdfFileName);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, "getModeloContrato");
                return null;
            }
        }
    }
}
