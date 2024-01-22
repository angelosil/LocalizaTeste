using Dapper;
using locacaoAPI.Models;
using locacaoAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly IDbConnection _dbConnection;
        
        public EnderecoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;            
        }
        
        public void Insert(Endereco endereco)
        {
            try
            {
                var query = @"INSERT INTO tblendereco (idcli,nomend ,cepend,ufend, cidend, baiend, numend, compend)
                            VALUES
	                        (@idcli, @nomend, @cepend, @ufend, @cidend, @baiend, @numend, @compend) ";

                var parameters = new
                {
                    idcli = endereco.ClienteID,
                    nomend = endereco.Logradouro,
                    cepend = endereco.CEP,
                    ufend = endereco.Estado,
                    cidend = endereco.Cidade,
                    baiend =endereco.Bairro,
                    numend = endereco.Numero,
                    compend = endereco.Complemento
                };

                _dbConnection.Query(query, parameters);               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Endereco>> getPorCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> getPorID(int id)
        {
            throw new NotImplementedException();
        }

        

        public void Update(Endereco endereco)
        {
            throw new NotImplementedException();
        }
    }
}
