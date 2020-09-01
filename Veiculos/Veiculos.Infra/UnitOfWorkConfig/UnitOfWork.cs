using System;
using System.Data;
using Veiculos.Infra.Data.Repositorios;
using Veiculos.Infra.Interfaces;
using Veiculos.Infra.Interfaces.Repositorios;

namespace Veiculos.Infra.UnitOfWorkConfig
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;

        public UnitOfWork(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICarroRepositorio CarroRepositorio => new CarroRepositorio(_dbConnection, _dbTransaction);

        public IDisposable BeginTransaction()
        {
            _dbTransaction?.Dispose();

            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();

            _dbTransaction = _dbConnection.BeginTransaction(IsolationLevel.ReadCommitted);

            return this;
        }

        public void Commit()
        {
            _dbTransaction?.Commit();
        }

        public void Dispose()
        {
            if (_dbTransaction != null)
            {
                _dbTransaction.Dispose();
                _dbTransaction = null;
            }
        }

        public void RollBack()
        {
            _dbTransaction?.Rollback();
        }
    }
}
