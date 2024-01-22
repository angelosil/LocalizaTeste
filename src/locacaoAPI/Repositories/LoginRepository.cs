using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using locacaoAPI.Models;
using Dapper;
using locacaoAPI.Services;
using locacaoAPI.Interfaces;

namespace locacaoAPI.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnection _dbConnection;
        private ICriptografiaService _criptografiaService;

        public LoginRepository(IDbConnection dbConnection, ICriptografiaService criptografiaService)
        {
            _dbConnection = dbConnection;
            _criptografiaService = criptografiaService;
        }

        public async Task<IEnumerable<Operador>> operadorLogin(LoginDTO loginDTO)
        {
            var query = @"SELECT op.matope, op.nomope, op.iduse, per.iduseper, per.nomuseper FROM tbloperador op 
                            INNER JOIN tbluser us ON us.iduse = OP.iduse 
                            INNER JOIN tbluserperfil per ON per.iduseper = us.iduseper 
                            WHERE op.matope = @Login AND us.passuse = @Password";

            var parameters = new
            {
                Login = loginDTO.Login,
                Password = _criptografiaService.CriptografarSenha(loginDTO.Login, loginDTO.Password)
            };

            var resultado = await  _dbConnection.QueryAsync(query, parameters);

            return resultado.Select(operador => new Operador
            {
                Matricula = operador.matope,
                Nome = operador.nomope,
                usuario = new Usuario
                {
                    Id = operador.iduse,
                    usuarioPerfil = new UsuarioPerfil
                    {
                        Id = operador.iduseper,
                        Nome = operador.nomuseper
                    }
                },                

            });
        }

        public async Task<IEnumerable<Cliente>> clienteLogin(LoginDTO loginDTO)
        {
            var query = @"SELECT cli.idcli, cli.iduse, per.iduseper, per.nomuseper FROM tblcliente cli 
                            INNER JOIN tbluser us ON us.iduse = cli.iduse 
                            INNER JOIN tbluserperfil per ON per.iduseper = us.iduseper 
                            WHERE cli.numcpfcli = @Login AND us.passuse = @Password";

            var parameters = new
            {
                Login = loginDTO.Login.Trim(),
                Password = _criptografiaService.CriptografarSenha(loginDTO.Login.Trim(), loginDTO.Password)
            };

            var resultado = await _dbConnection.QueryAsync(query, parameters);

            return resultado.Select(cliente => new Cliente
            {
                Id = cliente.idcli,                
                Usuario = new Usuario
                {
                    Id = cliente.iduse,
                    usuarioPerfil = new UsuarioPerfil
                    {
                        Id = cliente.iduseper,
                        Nome = cliente.nomuseper
                    }
                },

            });
        }
    }
}
