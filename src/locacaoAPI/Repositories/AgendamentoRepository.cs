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
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly IDbConnection _dbConnection;
        
        public AgendamentoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;            
        }

        public async Task<IEnumerable<Agendamento>> getAllByCliente(int idCliente)
        {
            try
            {
                var query = @"SELECT age.idage
                                      ,age.datage
                                      ,age.idcli
                                      ,age.idvei
                                      ,age.valhorage
                                      ,age.totHorage
                                      ,age.valTotal
                                      ,age.staage
                                      ,age.datRetirada
                                      ,age.datRetorno
	                                  ,cli.nomcli
	                                  ,vei.plavei
                                  FROM tblagendamento age
                                  inner join tblcliente cli ON cli.idcli = age.idcli
                                  inner join tblveiculo vei ON vei.idvei = age.idvei
                                    where age.idcli = @idcli ";

                var parameters = new
                {
                    idcli = idCliente
                };

                var resultado = await _dbConnection.QueryAsync(query, parameters);

                return resultado.Select(dados => new Agendamento
                {
                    Id = dados.idage,
                    DataAgendamento = dados.datage,
                    ValorHora = dados.valhorage,
                    TotalHora = dados.totHorage,
                    ValorTotal = dados.valTotal,
                    DataRetirada = dados.datRetirada,
                    DataEntrega = dados.datRetorno,
                    Status = dados.staage,
                    Cliente = new Cliente
                    {
                        Id = dados.idcli,
                        Nome = dados.nomcli

                    },
                    Veiculo = new Veiculo
                    {
                        Id = dados.idvei,
                        Placa = dados.plavei

                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Agendamento> getAllByID(int id)
        {         
                    try
                    {
                        var query = @"SELECT age.idage
                                      ,age.datage
                                      ,age.idcli
                                      ,age.idvei
                                      ,age.valhorage
                                      ,age.totHorage
                                      ,age.valTotal
                                      ,age.staage
                                      ,age.datRetirada
                                      ,age.datRetorno
	                                  ,cli.nomcli
	                                  ,vei.plavei
                                  FROM tblagendamento age
                                  inner join tblcliente cli ON cli.idcli = age.idcli
                                  inner join tblveiculo vei ON vei.idvei = age.idvei
                                    where age.idage = @idage ";

                        var parameters = new
                        {
                            idage = id
                        };

                        var resultado = await _dbConnection.QueryAsync(query, parameters);

                        return resultado.Select(dados => new Agendamento
                        {
                            Id = dados.idage,
                            DataAgendamento = dados.datage,
                            ValorHora = dados.valhorage,
                            TotalHora = dados.totHorage,
                            ValorTotal = dados.valTotal,
                            DataRetirada = dados.datRetirada,
                            DataEntrega = dados.datRetorno,
                            Status = dados.staage,
                            Cliente = new Cliente
                            {
                                Id = dados.idcli,
                                Nome = dados.nomcli

                            },
                            Veiculo = new Veiculo
                            {
                                Id = dados.idvei,
                                Placa = dados.plavei

                            }
                        }).First();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
             
        }

        public async Task<Agendamento> Insert(Agendamento agendamento)
        {
            try
            {

                string sql = @"INSERT INTO tblagendamento
                           (datage
                           ,idcli
                           ,idvei
                           ,valhorage
                           ,totHorage
                           ,staage
                           )
                            VALUES
                           (@datage
                           ,@idcli
                           ,@idvei
                           ,@valhorage
                           ,@totHorage
                           ,@staage
                           ); 
                           SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters = new
                {
                    datage = agendamento.DataAgendamento,
                    idcli = agendamento.Cliente.Id,
                    idvei = agendamento.Veiculo.Id,
                    valhorage = agendamento.ValorHora,
                    totHorage = agendamento.TotalHora,
                    staage = agendamento.Status
                };

                agendamento.Id = await _dbConnection.QueryFirstAsync<int>(sql, parameters);


                return agendamento;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
