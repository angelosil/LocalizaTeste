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
    public class ModeloRepository : IModeloRepository
    {

        private readonly IDbConnection _dbConnection;

        public ModeloRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public  Task<Modelo> Delete(Modelo Marca)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Modelo>> getAllByMarca(int idMarca)
        {
            try
            {
                var query = @"SELECT mo.idmod, mo.idmar, mo.nommod, ma.nommar FROM tblmodelo mo
                                INNER JOIN tblmarca ma ON ma.idmar = mo.idmar
                            where mo.idmar = @idmar order by nommod";

                var parameters = new
                {
                    idmar = idMarca
                };

                var resultado = await _dbConnection.QueryAsync(query, parameters);

                return resultado.Select(dados => new Modelo
                {
                    Id = dados.idmod,
                    Nome = dados.nommod,
                    Marca = new Marca
                    {
                        Id = dados.idmar,
                        Nome = dados.nommar
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Modelo> getPorID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Modelo> Insert(Modelo Marca)
        {
            throw new NotImplementedException();
        }

        public Task<Modelo> Update(Modelo Marca)
        {
            throw new NotImplementedException();
        }
    }
}
