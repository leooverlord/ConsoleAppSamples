using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Data.Querys.Consulta;
using Veiculos.Infra.Data.Querys.Peristencia;
using Veiculos.Infra.Interfaces.Repositorios;

namespace Veiculos.Infra.Data.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        private CarroConsulta _consulta;
        private CarroPersistencia _persistencia;

        public CarroRepositorio(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;

            _consulta = new CarroConsulta(_connection, _transaction);
            _persistencia = new CarroPersistencia(_connection, _transaction);
        }

        public async Task<IEnumerable<Carro>> ObterTodos()
        {
            return await _consulta.ObterTodos();
        }

        public async Task Salvar(Carro carro)
        {
            await _persistencia.Salvar(carro);
        }
    }
}
