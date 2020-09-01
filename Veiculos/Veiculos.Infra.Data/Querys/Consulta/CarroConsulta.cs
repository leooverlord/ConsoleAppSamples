using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Enums;

namespace Veiculos.Infra.Data.Querys.Consulta
{
    public class CarroConsulta
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;
        

        string sql = @"select 
                        Id, 
                        Nome, 
                        Ano, 
                        TipoVeiculoId as TipoVeiculo
                        from Veiculos
                        where TipoVeiculoId = @tipoVeiculo";

        public CarroConsulta(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<IEnumerable<Carro>> ObterTodos()
        {
            return await _connection.QueryAsync<Carro>(sql, new { tipoVeiculo = TipoVeiculoEnum.Carro }, _transaction);
        }
    }
}
