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
    public class MarcaRepository : IMarcaRepository
    {
        private readonly IDbConnection _dbConnection;

        public MarcaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

       

        public async Task<IEnumerable<Marca>> getAll()
        {
            try {
                var query = @"select idmar, nommar from tblmarca order by nommar";

                var resultado = await _dbConnection.QueryAsync(query);

                return resultado.Select(dados => new Marca
                {
                    Id = dados.idmar,
                    Nome = dados.nommar
                });                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Marca> getPorID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Insert(Marca Marca)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Update(Marca Marca)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Delete(Marca Marca)
        {
            throw new NotImplementedException();
        }
    }
}
