using Dapper.FluentMap;
using locacaoAPI.Models;
using locacaoAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using locacaoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using locacaoAPI.Interfaces;


namespace locacaoAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class LoginController : ControllerBase
        {

            private readonly ILogger<LoginController> _logger;
            private readonly ILoginRepository _LoginRepository;
            private readonly IClienteRepository _ClienteRepository;
            private readonly IJwtToken _jtwtoken;

            public LoginController(ILogger<LoginController> logger, ILoginRepository LoginRepository, IClienteRepository ClienteRepository, IJwtToken jtwtoken)
            {
                _logger = logger;
                _LoginRepository = LoginRepository;
                _ClienteRepository = ClienteRepository;
                _jtwtoken = jtwtoken;
            }


            [HttpPost]            
            [AllowAnonymous]
            public async Task<IActionResult> Login([FromBody] LoginDTO login)
            {
                try
                { 
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }                

                    switch (login.Perfil)
                    {

                        case 1:
                            Operador operadorRetorno = new Operador();
                            var OperadorLista = await _LoginRepository.operadorLogin(login);

                            if (OperadorLista == null || !OperadorLista.Any())
                            {
                                return StatusCode(StatusCodes.Status404NotFound, "Usuario não encontrado ou login/senha invalidos");
                            }
                            else
                            {
                                operadorRetorno = OperadorLista.First();                                
                                operadorRetorno.usuario.Token = _jtwtoken.GenerateToken(operadorRetorno.Nome, operadorRetorno.usuario.usuarioPerfil.Nome);

                               return Ok(operadorRetorno);
                            }
                        case 2:
                            
                            Cliente clienteRetorno = new Cliente();

                            var clienteLista = await _LoginRepository.clienteLogin(login);


                            if (clienteLista == null || !clienteLista.Any())
                            {
                                return StatusCode(StatusCodes.Status404NotFound, "Cliente não encontrado ou login/senha invalidos");
                            }
                            else
                            {
                                clienteRetorno = clienteLista.First();
                                clienteRetorno = await _ClienteRepository.getPorID(clienteRetorno.Id);
                                clienteRetorno.Usuario.Token = _jtwtoken.GenerateToken(clienteRetorno.Nome, clienteRetorno.Usuario.usuarioPerfil.Nome) ;

                                return Ok(clienteRetorno);
                            }
                            
                        default:
                                return StatusCode(StatusCodes.Status400BadRequest, "Perfil invalido");

                        }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Login_operador");
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

        }
    }

