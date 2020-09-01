using System.Data;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Interfaces.Repositorios;

namespace Veiculos.Infra.Data.Repositorios
{
    public class HelicopteroRepositorio : VeiculosRepositorio<Helicoptero>, IHelicopteroRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public HelicopteroRepositorio(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
    }
}
