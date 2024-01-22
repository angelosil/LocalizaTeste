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


namespace locacaoAPITest.Modelo
{
    public class ModeloControllerTests
    {
        [Fact]
        public async Task GetAllByMarca()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ModeloController>>();
            var mockModeloRepository = new Mock<IModeloRepository>();

            // Assuming that your repository method is expected to return a list of Modelo objects
            var mockModeloList = new List<locacaoAPI.Models.Modelo>
        {
            new locacaoAPI.Models.Modelo { Id = 1, Nome = "Modelo1", Marca = new locacaoAPI.Models.Marca { Id = 1, Nome = "Marca1" } },
            new locacaoAPI.Models.Modelo { Id = 2, Nome = "Modelo2", Marca = new locacaoAPI.Models.Marca { Id = 1, Nome = "Marca1" } }
        };

            mockModeloRepository.Setup(repo => repo.getAllByMarca(It.IsAny<int>())).ReturnsAsync(mockModeloList);

            var modeloController = new ModeloController(mockLogger.Object, mockModeloRepository.Object);

            var result = await modeloController.getAllByMarca(1);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedModeloList = Assert.IsAssignableFrom<IEnumerable<locacaoAPI.Models.Modelo>>(okObjectResult.Value);

            Assert.Equal(mockModeloList.Count, returnedModeloList.Count());
            mockModeloRepository.Verify(repo => repo.getAllByMarca(1), Times.Once);
        }
    }
}
