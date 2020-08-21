using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces;

namespace Veiculos.Infra.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private List<Carro> _carros;

        public CarroRepositorio()
        {
            _carros = _carros ?? new List<Carro>();
        }

        public async Task<IEnumerable<Carro>> ObterTodos()
        {
            return await Task.Run(() => _carros);
        }

        public async Task Salvar(Carro carro)
        {
            await Task.Run(() => _carros.Add(carro));
        }
    }
}
