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
    public class CombustivelRepository : ICombustivelRepository
    {

        private readonly IDbConnection _dbConnection;

        public CombustivelRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<Combustivel> Delete(Combustivel Marca)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Combustivel>> getAll()
        {
            try
            {
                var query = @"select idcom, nomcom from tblcombustivel order by nomcom";

                var resultado = await _dbConnection.QueryAsync(query);

                return resultado.Select(dados => new Combustivel
                {
                    Id = dados.idcom,
                    Nome = dados.nomcom
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Combustivel> getPorID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Combustivel> Insert(Combustivel Marca)
        {
            throw new NotImplementedException();
        }

        public Task<Combustivel> Update(Combustivel Marca)
        {
            throw new NotImplementedException();
        }
    }
}
