using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Enums;

namespace Veiculos.Infra.Data.Querys.Consulta
{
    public class VeiculosConsulta<T> where T : Veiculo
    {
        private readonly IDbConnection _connection;

        string sql = @"select 
                        Id, 
                        Nome, 
                        Ano, 
                        TipoVeiculoId as TipoVeiculo
                        from Veiculos
                        where TipoVeiculoId = @tipoVeiculo";

        public VeiculosConsulta(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<T>> ObterTodos(TipoVeiculoEnum tipoVeiculo)
        {
            return await _connection.QueryAsync<T>(sql, new { tipoVeiculo = tipoVeiculo });
        }
    }
}
