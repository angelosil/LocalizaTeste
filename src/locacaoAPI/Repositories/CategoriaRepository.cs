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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IDbConnection _dbConnection;

        public CategoriaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<Categoria> Delete(Categoria Marca)
        {
            throw new NotImplementedException();
        }              

        public async Task<IEnumerable<Categoria>> getAll()
        {
            try
            {
                var query = @"select idcat, nomcat from tblcategoria order by nomcat";

                var resultado = await _dbConnection.QueryAsync(query);

                return resultado.Select(dados => new Categoria
                {
                    Id = dados.idcat,
                    Nome = dados.nomcat
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Categoria> getPorID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> Insert(Categoria Marca)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> Update(Categoria Marca)
        {
            throw new NotImplementedException();
        }
    }
}
