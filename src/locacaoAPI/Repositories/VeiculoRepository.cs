using Dapper;
using locacaoAPI.Interfaces;
using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace locacaoAPI.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly IDbConnection _dbConnection;        

        public VeiculoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;            
        }
               

        public async Task<IEnumerable<Veiculo>> getAll()
        {
            {
                try
                {
                    var query = @"SELECT v.idvei
                                  ,v.idmar
                                  ,v.idmod
                                  ,v.idcat
                                  ,v.idcom
                                  ,v.plavei
                                  ,v.numlimpormalvei
                                  ,v.valhorvei
                                  ,v.anovei
	                              ,ma.nommar
	                              ,mo.nommod
	                              ,ca.nomcat
	                              ,co.nomcom
                              FROM tblveiculo v
                              INNER JOIN tblmarca ma ON ma.idmar = v.idmar
                              INNER JOIN tblmodelo mo ON mo.idmod = v.idmod
                              INNER JOIN tblcategoria ca ON ca.idcat = v.idcat
                              INNER JOIN tblcombustivel co ON co.idcom = v.idcom";

                    var resultado = await _dbConnection.QueryAsync(query);

                    return resultado.Select(dados => new Veiculo
                    {
                        Id = dados.idvei,
                        Placa = dados.plavei,
                        LimitePortaMala = dados.numlimpormalvei,
                        ValorHora = dados.valhorvei,
                        Ano = dados.anovei,
                        Modelo = new Modelo
                        {
                            Id = dados.idmod,
                            Nome = dados.nommod,
                            Marca = new Marca
                            {
                                Id = dados.idmar,
                                Nome = dados.nommar
                            },
                        },
                        Categoria = new Categoria
                        {
                            Id = dados.idcat,
                            Nome = dados.nomcat
                        },
                        Combustivel = new Combustivel
                        {
                            Id = dados.idcom,
                            Nome = dados.nomcom
                        }
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<Veiculo> getPorID(int id)
        {
                    try
                    {
                        var query = @"SELECT v.idvei
                                  ,v.idmar
                                  ,v.idmod
                                  ,v.idcat
                                  ,v.idcom
                                  ,v.plavei
                                  ,v.numlimpormalvei
                                  ,v.valhorvei
                                  ,v.anovei
	                              ,ma.nommar
	                              ,mo.nommod
	                              ,ca.nomcat
	                              ,co.nomcom
                              FROM tblveiculo v
                              INNER JOIN tblmarca ma ON ma.idmar = v.idmar
                              INNER JOIN tblmodelo mo ON mo.idmod = v.idmod
                              INNER JOIN tblcategoria ca ON ca.idcat = v.idcat
                              INNER JOIN tblcombustivel co ON co.idcom = v.idcom
                              where v.idvei = @idvei ";

                        var parameters = new
                        {
                            idvei = id                            
                        };

                        var resultado = await _dbConnection.QueryAsync(query, parameters);

                        return resultado.Select(dados => new Veiculo
                        {
                            Id = dados.idvei,
                            Placa = dados.plavei,
                            LimitePortaMala = dados.numlimpormalvei,
                            ValorHora = dados.valhorvei,
                            Ano = dados.anovei,                            
                            Modelo = new Modelo
                            {
                                Id = dados.idmod,
                                Nome = dados.nommod,
                                Marca = new Marca
                                {
                                    Id = dados.idmar,
                                    Nome = dados.nommar
                                },
                            },
                            Categoria = new Categoria
                            {
                                Id = dados.idcat,
                                Nome = dados.nomcat
                            },
                            Combustivel = new Combustivel
                            {
                                Id = dados.idcom,
                                Nome = dados.nomcom
                            }
                        }).First();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
        }

        public async Task<Veiculo> Insert(Veiculo veiculo)
        {
            try {

                string sql = @"INSERT INTO tblveiculo
                   (idmar
                   , idmod
                   , idcat
                   , idcom
                   , plavei
                   , numlimpormalvei
                   , valhorvei
                   , anovei)
                    VALUES
                  (@idmar
                   , @idmod
                   , @idcat
                   , @idcom
                   , @plavei
                   , @numlimpormalvei
                   , @valhorvei
                   , @anovei); 
                   SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters = new
                {
                    idmar = veiculo.Modelo.Marca.Id,
                    idmod = veiculo.Modelo.Id,
                    idcat = veiculo.Categoria.Id,
                    idcom = veiculo.Combustivel.Id,
                    plavei = veiculo.Placa,
                    numlimpormalvei = veiculo.LimitePortaMala,
                    valhorvei = veiculo.ValorHora,
                    anovei = veiculo.Ano
                };

                veiculo.Id = await _dbConnection.QueryFirstAsync<int>(sql, parameters);


                return veiculo;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }

        public void Delete(Veiculo veiculo)
        {
            throw new NotImplementedException();
        }
    }
}
