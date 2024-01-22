using locacaoAPI.Controllers;
using locacaoAPI.Interfaces;
using locacaoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace locacaoAPITest.Marca
{

    public class MarcaControllerTests
    {
        [Fact]
        public async Task GetAll()
        {

            var mockLogger = new Mock<ILogger<MarcaController>>();
            var mockRepository = new Mock<IMarcaRepository>();


            var mockMarcaList = new List<locacaoAPI.Models.Marca>
            {
                new  locacaoAPI.Models.Marca { Id = 1, Nome = "Marca1" },
                new  locacaoAPI.Models.Marca { Id = 2, Nome = "Marca2" }
            };

            mockRepository.Setup(repo => repo.getAll()).ReturnsAsync(mockMarcaList);

            var categoriaController = new MarcaController(mockLogger.Object, mockRepository.Object);

            var result = await categoriaController.getAll();

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedMarcaList = Assert.IsAssignableFrom<IEnumerable<locacaoAPI.Models.Marca>>(okObjectResult.Value);

            Assert.Equal(mockMarcaList.Count, returnedMarcaList.Count());
            mockRepository.Verify(repo => repo.getAll(), Times.Once);
        }
    }
}
