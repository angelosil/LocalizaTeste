using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using locacaoAPI.Controllers;
using locacaoAPI.Interfaces;
using locacaoAPI.Models;

namespace locacaoAPITest.ClienteTest
{
    public class ClienteControllerTests
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _clienteRepository;

        public ClienteControllerTests()
        {
            _logger = Mock.Of<ILogger<ClienteController>>();
            _clienteRepository = Mock.Of<IClienteRepository>();
        }

        [Fact]
        public async Task Insert()
        {
            
            var cliente = new Cliente();
            var controller = new ClienteController(_logger, _clienteRepository);
                        
            var result = await controller.insert(cliente);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = new returnObjeto
            {
                resultado = (string)okResult.Value.GetType().GetProperty("resultado").GetValue(okResult.Value, null),
                status = (string)okResult.Value.GetType().GetProperty("status").GetValue(okResult.Value, null)
            };

            Assert.Equal("Cliente incluido com sucesso", returnValue.resultado);
            Assert.Equal("ok", returnValue.status);

        }


        class returnObjeto
        {
            public string resultado { get; set; }
            public string status { get; set; }

        }
    }
}