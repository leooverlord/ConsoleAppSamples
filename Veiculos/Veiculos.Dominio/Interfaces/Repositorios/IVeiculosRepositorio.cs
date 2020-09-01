using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Dominio.Interfaces.Repositorios
{
    public interface IVeiculosRepositorio<T> where T : Veiculo
    {
        Task<IEnumerable<T>> ObterTodos();
        Task Salvar(T veiculo);
    }
}
