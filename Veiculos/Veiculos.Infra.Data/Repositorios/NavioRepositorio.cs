using System.Data;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Interfaces.Repositorios;

namespace Veiculos.Infra.Data.Repositorios
{
    public class NavioRepositorio : VeiculosRepositorio<Navio>, INavioRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public NavioRepositorio(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
    }
}
