using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Infra.Interfaces.Repositorios
{
    public interface ICarroRepositorio
    {
        Task<IEnumerable<Carro>> ObterTodos();
        Task Salvar(Carro carro);
    }
}
