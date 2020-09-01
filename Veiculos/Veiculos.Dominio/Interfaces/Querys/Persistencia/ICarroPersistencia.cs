using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Dominio.Interfaces.Querys.Persistencia
{
    public interface ICarroPersistencia
    {
        Task Salvar(Carro carro);
    }
}
