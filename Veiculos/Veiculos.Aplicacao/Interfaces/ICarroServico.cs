using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Aplicacao.Interfaces
{
    public interface ICarroServico
    {
        Task<IEnumerable<Carro>> ObterTodos();
        Task Salvar(Carro carro);
    }
}
