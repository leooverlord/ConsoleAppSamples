using System.Collections.Generic;
using System.Threading.Tasks;
using Veiculos.Aplicacao.Interfaces;
using Veiculos.Dominio.Entidades;
using Veiculos.Infra.Interfaces;

namespace Veiculos.Aplicacao.Servicos
{
    public class CarroServico : ICarroServico
    {
        private readonly ICarroRepositorio _repositorio;
        public CarroServico(ICarroRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<Carro>> ObterTodos()
        {
            return await _repositorio.ObterTodos();
        }

        public async Task Salvar(Carro carro)
        {
            await _repositorio.Salvar(carro);
        }
    }
}
