using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces.Repositorios;

namespace Veiculos.Infra.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        #region Sql
        string sqlSelect = "select Id, Nome, Ano, TipoVeiculoId from Veiculos";
        string sqlInsert = "insert into Veiculos (Id, Nome, Ano, TipoVeiculoId) values (@id, @nome, @ano, @tipo)"; 
        #endregion

        public CarroRepositorio(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<IEnumerable<Carro>> ObterTodos()
        {
            return await _connection.QueryAsync<Carro>(sqlSelect, transaction: _transaction);
        }

        public async Task Salvar(Carro carro)
        {
            var parametros = new
            {
                id = carro.Id,
                nome = carro.Nome,
                ano = carro.Ano,
                tipo = carro.TipoVeiculo
            };

            await _connection.ExecuteAsync(sqlInsert, parametros, _transaction);
            _transaction.Commit();
            _transaction.Dispose();
        }
    }
}

