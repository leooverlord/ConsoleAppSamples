using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Enums;
using Veiculos.Dominio.Interfaces.Querys.Consultas;

namespace Veiculos.Infra.Data.Querys.Consulta
{
    public class CarroConsulta : ICarroConsulta
    {
        private readonly IDbConnection _connection;

        string sql = @"select 
                        Id, 
                        Nome, 
                        Ano, 
                        TipoVeiculoId as TipoVeiculo
                        from Veiculos
                        where TipoVeiculoId = @tipoVeiculo";

        public CarroConsulta(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Carro>> ObterTodos()
        {
            return await _connection.QueryAsync<Carro>(sql, new { tipoVeiculo = TipoVeiculoEnum.Carro });
        }
    }
}
