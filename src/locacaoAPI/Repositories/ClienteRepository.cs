using locacaoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using locacaoAPI.Services;
using locacaoAPI.Interfaces;

namespace locacaoAPI.Repositories
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly IDbConnection _dbConnection;
        private ICriptografiaService _criptografiaService;

        public ClienteRepository(IDbConnection dbConnection, ICriptografiaService criptografiaService)
        {
            _dbConnection = dbConnection;
            _criptografiaService = criptografiaService;
        }


        public async Task<Cliente> getPorID(int id)
        {
            try
            {
                var query = @"SELECT cli.idcli,cli.nomcli, cli.numcpfcli, cli.dtnasccli, cli.iduse, 
                                us.iduse, per.iduseper, per.nomuseper, ende.idend, ende.nomend, ende.cepend, ende.ufend, ende.cidend, ende.baiend, ende.numend, ende.compend  
                                FROM tblcliente cli 
                                INNER JOIN tbluser us ON us.iduse = cli.iduse
                                INNER JOIN tbluserperfil per ON us.iduseper = per.iduseper
                                LEFT JOIN tblendereco ende ON ende.idcli = cli.idcli
                                where cli.idcli = @Id ";

                var parameters = new
                {
                    Id = id                    
                };

                var resultado = await _dbConnection.QueryAsync(query, parameters);

                var ret = resultado.Select((dados) => 
                {
                        var cliente = new Cliente {
                        Id = dados.idcli,
                        Nome = dados.nomcli,
                        Cpf = dados.numcpfcli,
                        DataNascimento = Convert.ToDateTime(dados.dtnasccli),
                        Usuario = new Usuario
                        {
                            Id = dados.iduse,
                            usuarioPerfil = new UsuarioPerfil
                            {
                                Id = dados.iduseper,
                                Nome = dados.nomuseper
                            }
                        },
                    };

                    if (dados.idend != null)
                    {
                        cliente.Endereco = new Endereco
                        {
                            Id = dados.idend,
                            ClienteID = dados.idcli,
                            Logradouro = dados.nomend,
                            CEP = dados.cepend,
                            Numero = dados.numend,
                            Complemento = dados.compend,
                            Bairro = dados.baiend,
                            Cidade = dados.cidend,
                            Estado = dados.ufend,
                        };
                    }

                    return cliente;
                });

                return ret.First(); 

            }
            catch ( Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Cliente> Insert(Cliente cliente)
        {
            _dbConnection.Open();

            var transaction = _dbConnection.BeginTransaction();

            try
            {

                //Por padrão, ao incluir um novo operador é criado um cliente.
                //A senha, se não for informado, será usando o CPF

                string sql = "INSERT INTO tbluser(passuse, iduseper) values (@senha, @iduserperfil ); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters = new
                {
                    senha = _criptografiaService.CriptografarSenha(cliente.Cpf.ToString(), string.IsNullOrEmpty(cliente.Usuario.Senha) ? cliente.Cpf.ToString() : cliente.Usuario.Senha.Trim()),
                    iduserperfil = (int)enumPerfil.Cliente
                };

                cliente.Usuario.Id = await _dbConnection.QueryFirstAsync<int>(sql, parameters, transaction);

                sql = @"INSERT INTO tblcliente (nomcli, numcpfcli, dtnasccli,iduse )
                        VALUES
                        (@nomcli, @numcpfcli, @dtnasccli, @iduse); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var parameters2 = new
                {
                    nomcli = cliente.Nome,
                    numcpfcli = cliente.Cpf.Trim(),
                    dtnasccli = Convert.ToDateTime(cliente.DataNascimento.ToString("yyyy-MM-dd")),
                    iduse = cliente.Usuario.Id
                };

                cliente.Id = await _dbConnection.QueryFirstAsync<int>(sql, parameters2, transaction);

                if (cliente.Endereco != null)
                {
                    sql = @"INSERT INTO tblendereco (idcli,nomend ,cepend,ufend, cidend, baiend, numend, compend)
                            VALUES
	                        (@idcli, @nomend, @cepend, @ufend, @cidend, @baiend, @numend, @compend) ";

                    var parameters3 = new
                    {
                        idcli = cliente.Id,
                        nomend = cliente.Endereco.Logradouro,
                        cepend = cliente.Endereco.CEP,
                        ufend = cliente.Endereco.Estado,
                        cidend = cliente.Endereco.Cidade,
                        baiend = cliente.Endereco.Bairro,
                        numend = cliente.Endereco.Numero,
                        compend = cliente.Endereco.Complemento
                    };

                    _dbConnection.Query(sql, parameters3, transaction);
                }

                transaction.Commit();

                return cliente;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public Task<IEnumerable<Cliente>> QueryAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
        public void Delete(Cliente cliente)
        {
            throw new NotImplementedException();
        }

    }
}
