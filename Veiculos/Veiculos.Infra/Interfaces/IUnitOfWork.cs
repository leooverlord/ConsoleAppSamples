using Veiculos.Infra.Interfaces.Repositorios;

namespace Veiculos.Infra.Interfaces
{
    public interface IUnitOfWork : ITransactionManager
    {
        ICarroRepositorio CarroRepositorio { get; }
    }
}
