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

namespace locacaoAPITest.Categoria
{
    public class CategoriaControllerTests
    {
        [Fact]
        public async Task GetAll()
        {
            
            var mockLogger = new Mock<ILogger<CategoriaController>>();
            var mockCategoriaRepository = new Mock<ICategoriaRepository>();

            
            var mockCategoriaList = new List<locacaoAPI.Models.Categoria>
            {
                new locacaoAPI.Models.Categoria { Id = 1, Nome = "Categoria1" },
                new locacaoAPI.Models.Categoria { Id = 2, Nome = "Categoria2" }            
            };

            mockCategoriaRepository.Setup(repo => repo.getAll()).ReturnsAsync(mockCategoriaList);

            var categoriaController = new CategoriaController(mockLogger.Object, mockCategoriaRepository.Object);
            
            var result = await categoriaController.getAll();
            
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnedCategoriaList = Assert.IsAssignableFrom<IEnumerable<locacaoAPI.Models.Categoria>>(okObjectResult.Value);

            Assert.Equal(mockCategoriaList.Count, returnedCategoriaList.Count());            
            mockCategoriaRepository.Verify(repo => repo.getAll(), Times.Once);
        }
    }
}
