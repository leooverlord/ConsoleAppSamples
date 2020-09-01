using Veiculos.Dominio.Interfaces.Repositorios;
using Veiculos.Infra.Interfaces.Repositorios;

namespace Veiculos.Infra.Interfaces
{
    public interface IUnitOfWork : ITransactionManager
    {
        ICarroRepositorio CarroRepositorio { get; }
        IMotoRepositorio MotoRepositorio { get; }
        IAviaoRepositorio AviaoRepositorio { get; }
        INavioRepositorio NavioRepositorio { get; }
        IHelicopteroRepositorio HelicopteroRepositorio { get; }
    }
}
