﻿using System.Data;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces.Repositorios;

namespace Veiculos.Infra.Data.Repositorios
{
    public class CarroRepositorio : VeiculosRepositorio<Carro>, ICarroRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public CarroRepositorio(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
    }
}
