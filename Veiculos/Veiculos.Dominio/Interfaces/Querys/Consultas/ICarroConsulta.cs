using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Dominio.Interfaces.Querys.Consultas
{
    public interface ICarroConsulta
    {
        Task<IEnumerable<Carro>> ObterTodos();
    }
}
