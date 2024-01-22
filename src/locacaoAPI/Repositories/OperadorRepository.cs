using Dapper;
using locacaoAPI.Models;
using locacaoAPI.Interfaces;
using locacaoAPI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Repositories
{
    public class OperadorRepository : IOperadorRepository
    {

        private readonly IDbConnection _dbConnection;
        private ICriptografiaService _criptografiaService;
        

        public OperadorRepository(IDbConnection dbConnection, ICriptografiaService criptografiaService)
        {
            _dbConnection = dbConnection;
            _criptografiaService = criptografiaService;
        }

        public void Delete(Operador operador)
        {
            throw new NotImplementedException();
        }

        public async Task<Operador> getPorMatricula(int matricula)
        {
            try
            {
                var query = @"SELECT op.matope, op.nomope, op.iduse, per.iduseper, per.nomuseper FROM tbloperador op 
                            INNER JOIN tbluser us ON us.iduse = OP.iduse 
                            INNER JOIN tbluserperfil per ON per.iduseper = us.iduseper 
                            WHERE op.matope = @matricula";

                var parameters = new
                {
                    matricula = matricula,                    
                };

                var resultado = await _dbConnection.QueryAsync(query, parameters);

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
                }).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Operador operador)
        {
            _dbConnection.Open();
            
            var transaction = _dbConnection.BeginTransaction();

            try {

                //Por padrão, ao incluir um novo operador é criado um usuario.
                //A senha, se não for informado, será usando a matricula

                string sql = "INSERT INTO tbluser(passuse, iduseper) values (@senha, @iduserperfil ); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters = new
                {
                    senha = _criptografiaService.CriptografarSenha(operador.Matricula.ToString(), string.IsNullOrEmpty(operador.usuario.Senha) ? operador.Matricula.ToString() : operador.usuario.Senha.Trim()),
                    iduserperfil = (int) enumPerfil.Operador
                };

                operador.usuario.Id =  _dbConnection.Query<int>(sql, parameters, transaction).Single();

                sql = @"INSERT INTO tbloperador(matope, nomope, iduse)
                        VALUES(@matope, @nomope, @iduse)";

                var parameters2 = new
                {
                    matope = operador.Matricula,
                    nomope = operador.Nome.Trim(),
                    iduse = operador.usuario.Id                
                };

                _dbConnection.Query(sql, parameters2, transaction);

                transaction.Commit();               
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public void Update(Operador operador)
        {
            throw new NotImplementedException();
        }
    }
}
