﻿using Dapper;
using System.Data;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Infra.Data.Querys.Peristencia
{
    public class CarroPersistencia
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        string sql = @"insert into Veiculos 
                        (Id, Nome, Ano, TipoVeiculoId) 
                    values 
                        (@Id, @Nome, @Ano, @TipoVeiculo)";

        public CarroPersistencia(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task Salvar(Carro carro)
        {
            await _connection.ExecuteAsync(sql, carro, _transaction);
        }
    }
}
