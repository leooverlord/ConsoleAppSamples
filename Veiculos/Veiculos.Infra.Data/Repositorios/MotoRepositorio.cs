using System.Data;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Interfaces.Repositorios;

namespace Veiculos.Infra.Data.Repositorios
{
    public class MotoRepositorio : VeiculosRepositorio<Moto>, IMotoRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public MotoRepositorio(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
    }
}
